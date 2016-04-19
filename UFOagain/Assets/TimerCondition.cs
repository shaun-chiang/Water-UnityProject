using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;
using System;

public class TimerCondition : MonoBehaviour {

    public GUISkin Skin;
    public int SecondsPerTurn;
    public double StartTime;
    private bool gamedone = false;
    private bool startRoundWhenTimeIsSynced;
    private const string StartTimeKey = "st";
    private bool gonextscene = false;

    private void StartRoundNow()
    {
        /*
        if (PhotonNetwork.isMasterClient)
        {
            this.StartRoundNow();
        }
        */
        // in some cases, when you enter a room, the server time is not available immediately.
        // time should be 0.0f but to make sure we detect it correctly, check for a very low value.
        
        if (PhotonNetwork.time < 0.0001f)
        {
            // we can only start the round when the time is available. let's check that in Update()

            startRoundWhenTimeIsSynced = true;
            return;
        }
        startRoundWhenTimeIsSynced = false;
        

        StartTime = PhotonNetwork.time;
        ExitGames.Client.Photon.Hashtable startTimeProp = new ExitGames.Client.Photon.Hashtable();  // only use ExitGames.Client.Photon.Hashtable for Photon
        startTimeProp[StartTimeKey] = PhotonNetwork.time;
        PhotonNetwork.room.SetCustomProperties(startTimeProp);              // implement OnPhotonCustomRoomPropertiesChanged(Hashtable propertiesThatChanged) to get this change everywhere
    }


    /// <summary>Called by PUN when this client entered a room (no matter if joined or created).</summary>
    public void Start()
    {
        if (PhotonNetwork.isMasterClient)
        {
            this.StartRoundNow();
            Debug.Log("Starting round with starttime " + PhotonNetwork.time+ " and seconds to survive is " +SecondsPerTurn);
           
        }
        else
        {
            // as the creator of the room sets the start time after entering the room, we may enter a room that has no timer started yet
            Debug.Log("StartTime already set: " + PhotonNetwork.room.customProperties.ContainsKey(StartTimeKey));
        }
    }
    /// <summary>Called by PUN when new properties for the room were set (by any client in the room).</summary>
    public void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey(StartTimeKey))
        {
            StartTime = (double)propertiesThatChanged[StartTimeKey];
        }
    }
    public void OnMasterClientSwitched(PhotonPlayer newMasterClient)
    {
        if (!PhotonNetwork.room.customProperties.ContainsKey(StartTimeKey))
        {
            Debug.Log("The new master starts a new round, cause we didn't start yet.");
            this.StartRoundNow();
        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3.0f);
        gonextscene = true;
    }
    void Update()
    {
        
        if (startRoundWhenTimeIsSynced)
        {
            this.StartRoundNow();   // the "time is known" check is done inside the method.
        }
    }

    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));

        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        // alternatively to doing this calculation here:
        // calculate these values in Update() and make them publicly available to all other scripts

        double elapsedTime = (PhotonNetwork.time - StartTime);
        double remainingTime = SecondsPerTurn - (elapsedTime % SecondsPerTurn);
        int turn = (int)(elapsedTime / SecondsPerTurn);

        if (gonextscene==true)
        {
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }

        if ((remainingTime < 0.1)|(gamedone)) {
            gamedone = true;
            StartCoroutine(Example());
            GUI.Window(0, new Rect(120,65,250,200), WindowFunction, "Level " + PlayerPrefs.GetString("Level") + " Finished!");
            GUILayout.BeginArea(new Rect(316, 2, 150, 300));
            GUILayout.Label("You Win!");
            GUILayout.EndArea();

        }
        else { 
        // simple gui for output
        GUILayout.BeginArea(new Rect(316, 2, 150, 300));
        GUILayout.Label(string.Format("Remaining: {0:0}", remainingTime));
        /*if (GUILayout.Button("new round"))
        {
            this.StartRoundNow();
        }*/
        GUILayout.EndArea();
    }
    }

    private void WindowFunction(int id)
    {
        GUILayout.Space(50);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("You survived!", GUI.skin.FindStyle("PlainText"));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Go to base camp"))
        {
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
        GUILayout.EndHorizontal();
    }
}
