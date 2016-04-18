using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections;
using System;

public class TimerCondition : MonoBehaviour {

    public GUISkin Skin;
    public int SecondsPerTurn = 30;
    public double StartTime;
    private bool gamedone = false;
    private bool startRoundWhenTimeIsSynced;
    private const string StartTimeKey = "st";

    private void StartRoundNow()
    {
        // in some cases, when you enter a room, the server time is not available immediately.
        // time should be 0.0f but to make sure we detect it correctly, check for a very low value.
        /*
        if (PhotonNetwork.time < 0.0001f)
        {
            // we can only start the round when the time is available. let's check that in Update()

            startRoundWhenTimeIsSynced = true;
            return;
        }
        startRoundWhenTimeIsSynced = false;
        */

        StartTime = PhotonNetwork.time;
        ExitGames.Client.Photon.Hashtable startTimeProp = new ExitGames.Client.Photon.Hashtable();  // only use ExitGames.Client.Photon.Hashtable for Photon
        startTimeProp[StartTimeKey] = PhotonNetwork.time;
        PhotonNetwork.room.SetCustomProperties(startTimeProp);              // implement OnPhotonCustomRoomPropertiesChanged(Hashtable propertiesThatChanged) to get this change everywhere
    }


    /// <summary>Called by PUN when this client entered a room (no matter if joined or created).</summary>
    public void OnJoinedRoom()
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
    void Start()
    {
        if (PhotonNetwork.isMasterClient) {
            this.StartRoundNow();
            }
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


        if ((remainingTime < 0.1)|(gamedone)) {
            gamedone = true;
            GUI.Window(0, new Rect(120,65,250,200), WindowFunction, "Level " + PlayerPrefs.GetString("Level") + " Finished!");
            GUILayout.BeginArea(new Rect(336, 2, 150, 300));
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
            int current = PlayerPrefs.GetInt("NextScene") + 1;
            PlayerPrefs.SetInt("NextScene", current);
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
        GUILayout.EndHorizontal();
    }
}
