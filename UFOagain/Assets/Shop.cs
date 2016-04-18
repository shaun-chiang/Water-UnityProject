using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    private bool inShop=false;
    public GUISkin Skin;
	// Use this for initialization
	void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        if (inShop)
        {
            GUI.Window(0, new Rect(30, 0, 420, 310), WindowFunction, "Shop");

        }
       
    }
    private void WindowFunction(int id)
    {
        GUILayout.Space(37);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(PlayerPrefs.GetString("Class"));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Current Gold :"+PhotonNetwork.player.GetScore(), GUI.skin.FindStyle("PlainText"));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Skill 1: Level "+PlayerPrefs.GetInt("Skill1Level"), GUI.skin.FindStyle("PlainText"));
        if ((GUILayout.Button("Buy: 100 Gold"))&&(PhotonNetwork.player.GetScore()>=100))
        {
            PlayerPrefs.SetInt("Skill1Level", PlayerPrefs.GetInt("Skill1Level") + 1);
            PhotonNetwork.player.AddScore(-100);
            Debug.Log("Bought Skill 1");

        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Skill 2: Level " + PlayerPrefs.GetInt("Skill2Level"), GUI.skin.FindStyle("PlainText"));
        if ((GUILayout.Button("Buy: 200 Gold")) && (PhotonNetwork.player.GetScore() >= 200))
        {
            PlayerPrefs.SetInt("Skill2Level", PlayerPrefs.GetInt("Skill2Level") + 1);
            PhotonNetwork.player.AddScore(-200);
            Debug.Log("Bought Skill 2");

        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Skill 3: Level " + PlayerPrefs.GetInt("Skill3Level"), GUI.skin.FindStyle("PlainText"));
        if ((GUILayout.Button("Buy: 300 Gold")) && (PhotonNetwork.player.GetScore() >= 300))
        {
            PlayerPrefs.SetInt("Skill3Level", PlayerPrefs.GetInt("Skill3Level") + 1);
            PhotonNetwork.player.AddScore(-300);
            Debug.Log("Bought Skill 3");

        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        /*
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Quit to Main Menu"))
        {
            Debug.Log("IM QUITTING!!!!!!!!");
            PlayerPrefs.SetString("NextScene", "Main Menu");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
        GUILayout.EndHorizontal();
        */
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Exit Shop"))
        {
            Debug.Log("IM going BACK!!!!!!!!");
            inShop = false;
        }
        GUILayout.EndHorizontal();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        // we only call Pickup() if "our" character collides with this PickupItem.
        // note: if you "position" remote characters by setting their translation, triggers won't be hit.

        PhotonView otherpv = other.GetComponent<PhotonView>();
        //Debug.Log("GetInstanceID: "+otherpv.GetInstanceID());
        //Debug.Log("Tag: "+ otherpv.tag);
        //Debug.Log("InstantiationID: "+otherpv.instantiationId);
        //Debug.Log("Name: "+otherpv.name);
        //Debug.Log("ViewID:" + otherpv.viewID);


        if (other.tag.Equals("Shop"))
        {
            //Debug.Log("OnTriggerEnter() calls Pickup().");
            inShop = true;
        }
    }

}
