using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

    public GUISkin Skin;
    public Texture2D archerTexture;
    public Texture2D mageTexture;
    public Texture2D paladinTexture;
    public Texture2D gunnerTexture;
	private string archerbutton;
	private string magebutton;
	private string gunnerbutton;
	private string paladinbutton;

    public static readonly string SceneNameMenu = "WaitingRoom";
    

    public static readonly string SceneNameGame = "InBetweenLoadingScenes";

    void Start()
    {
        PlayerPrefs.SetString("NextScene", "ongoing");
    }

    public void Awake()
    {
    }

    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        Rect content = new Rect(-7, -25, 495, 370);
        GUI.backgroundColor = Color.white;
        //WindowFunction(0);

        GUI.Window(0, content, WindowFunction, "Choose a character");
    }
    private void WindowFunction(int id)
    {

        Rect content = new Rect(28, 99, 435, 320);
        GUILayout.BeginArea(content);
		GUI.DrawTexture(new Rect(22,8,80,80),archerTexture);
        GUI.DrawTexture(new Rect(127, 5, 80, 90), mageTexture);
		GUI.DrawTexture(new Rect(233, 8, 90, 80), paladinTexture);
        GUI.DrawTexture(new Rect(338, 5, 80, 90), gunnerTexture);
        //GUILayout.Space(85);

		//archer
		GUI.Box(new Rect(15,0,95,208),"");
		GUI.Label (new Rect (5, 85, 115, 30), "Archer");
		//draw hp
		GUI.TextField (new Rect (20, 110, 30, 30), "HP",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (45, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (57, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (69, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (81, 110, 10, 10),false,"");
		GUI.Toggle(new Rect (93, 110, 10, 10),false,"");
		//draw atk
		GUI.TextField (new Rect (20, 125, 30, 30), "ATK",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (45, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (57, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (69, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (81, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (93, 125, 10, 10),false,"");
		//draw rng
		GUI.TextField (new Rect (20, 140, 30, 30), "RNG",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (45, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (57, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (69, 140, 10, 10),false,"");
		GUI.Toggle(new Rect (81, 140, 10, 10),false,"");
		GUI.Toggle(new Rect (93, 140, 10, 10),false,"");
		//draw button
		archerbutton = "Select";
		if (GUI.Button(new Rect(13, 170, 100, 25) ,(archerbutton)))
		{
            PlayerPrefs.SetString("Class", "Archer");
            PhotonNetwork.JoinOrCreateRoom(PlayerPrefs.GetString("roomName"), new RoomOptions() { maxPlayers = 4 }, null);

        }
        //mage
        GUI.Box(new Rect(120,0,95,208),"");
		GUI.Label (new Rect (110, 85, 115, 30), "Mage");
		//draw hp
		GUI.TextField (new Rect (125, 110, 30, 30), "HP",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (149, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (161, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (173, 110, 10, 10),false,"");
		GUI.Toggle(new Rect (185, 110, 10, 10),false,"");
		GUI.Toggle(new Rect (197, 110, 10, 10),false,"");
		//draw atk
		GUI.TextField (new Rect (125, 125, 30, 30), "ATK",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (149, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (161, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (173, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (185, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (197, 125, 10, 10),false,"");
		//draw rng
		GUI.TextField (new Rect (125, 140, 30, 30), "RNG",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (149, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (161, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (173, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (185, 140, 10, 10),false,"");
		GUI.Toggle(new Rect (197, 140, 10, 10),false,"");
		//draw button
		magebutton = "Select";
		if (GUI.Button(new Rect(118, 170, 100, 25) ,(magebutton)))
        {
            PlayerPrefs.SetString("Class", "Mage");
            PhotonNetwork.JoinOrCreateRoom(PlayerPrefs.GetString("roomName"), new RoomOptions() { maxPlayers = 4 }, null);

        }
        //paladin
        GUI.Box(new Rect(226,0,95,208),"");
		GUI.Label (new Rect (216, 85, 115, 30), "Paladin");
		//draw hp
		GUI.TextField (new Rect (231, 110, 30, 30), "HP",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (255, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (267, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (279, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (291, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (303, 110, 10, 10),false,"");
		//draw atk
		GUI.TextField (new Rect (231, 125, 30, 30), "ATK",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (255, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (267, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (279, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (291, 125, 10, 10),false,"");
		GUI.Toggle(new Rect (303, 125, 10, 10),false,"");
		//draw rng
		GUI.TextField (new Rect (231, 140, 30, 30), "RNG",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (255, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (267, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (279, 140, 10, 10),false,"");
		GUI.Toggle(new Rect (291, 140, 10, 10),false,"");
		GUI.Toggle(new Rect (303, 140, 10, 10),false,"");
		//draw button
		paladinbutton = "Select";
		if (GUI.Button(new Rect(224, 170, 100, 25) ,(paladinbutton)))
		{

            PlayerPrefs.SetString("Class", "Paladin"); //for now, change to paladin later
            PhotonNetwork.JoinOrCreateRoom(PlayerPrefs.GetString("roomName"), new RoomOptions() { maxPlayers = 4 }, null);

        }
        //gunner
        GUI.Box(new Rect(331,0,95,208),"");
		GUI.Label (new Rect (321, 85, 115, 30), "Gunner");
		//draw hp
		GUI.TextField (new Rect (336, 110, 30, 30), "HP",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (360, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (372, 110, 10, 10),true,"");
		GUI.Toggle(new Rect (383, 110, 10, 10),false,"");
		GUI.Toggle(new Rect (395, 110, 10, 10),false,"");
		GUI.Toggle(new Rect (407, 110, 10, 10),false,"");
		//draw atk
		GUI.TextField (new Rect (336, 125, 30, 30), "ATK",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (360, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (372, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (383, 125, 10, 10),true,"");
		GUI.Toggle(new Rect (395, 125, 10, 10),false,"");
		GUI.Toggle(new Rect (407, 125, 10, 10),false,"");
		//draw rng
		GUI.TextField (new Rect (336, 140, 30, 30), "RNG",GUI.skin.FindStyle("PlainText"));
		GUI.Toggle(new Rect (360, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (372, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (383, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (395, 140, 10, 10),true,"");
		GUI.Toggle(new Rect (407, 140, 10, 10),false,"");
		//draw button
		gunnerbutton = "Select";
		if (GUI.Button(new Rect(329, 170, 100, 25) ,(gunnerbutton)))
		{
            PlayerPrefs.SetString("Class", "Gunner");
            PhotonNetwork.JoinOrCreateRoom (PlayerPrefs.GetString ("roomName"), new RoomOptions () { maxPlayers = 4 }, null);
			
		}
		GUILayout.EndArea();


    }
    public void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
		PhotonNetwork.LoadLevel(SceneNameGame);
    }

    public void OnPhotonCreateRoomFailed()
    {
        Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
    }

    public void OnPhotonJoinRoomFailed(object[] cause)
    {
        Debug.Log("OnPhotonJoinRoomFailed got called. This can happen if the room is not existing or full or closed.");
    }

    public void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed got called. Happens if no room is available (or all full or invisible or closed). JoinrRandom filter-options can limit available rooms.");
    }

    public void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        PhotonNetwork.LoadLevel(SceneNameGame);
    }

    public void OnDisconnectedFromPhoton()
    {
        Debug.Log("Disconnected from Photon.");
    }

    public void OnFailedToConnectToPhoton(object parameters)
    {
        Debug.Log("OnFailedToConnectToPhoton. StatusCode: " + parameters + " ServerAddress: " + PhotonNetwork.ServerAddress);
    }

}
