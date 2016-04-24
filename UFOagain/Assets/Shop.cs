using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    private bool inShop=false;
    public GUISkin Skin;
    private int maxHp;
	// Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetString("Class").Equals("Paladin"))
        {
            maxHp = 125;
        }
        else if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {
            maxHp = 75;
        }
        else if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {
            maxHp = 75;
        }
        else if (PlayerPrefs.GetString("Class").Equals("Archer"))
        {
            maxHp = 100;
        }
    }
	void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        if (inShop)
        {
            GUI.Window(0, new Rect(30, 0, 420, 330), WindowFunction, "Shop");

        }
       
    }
    private void WindowFunction(int id)
    {
        GUILayout.Space(33);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(PlayerPrefs.GetString("Class"));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        
        GUILayout.Label("Current Gold :" + PhotonNetwork.player.GetScore() + " Current Health : " + PlayerPrefs.GetInt("HP"), GUI.skin.FindStyle("PlainText"));
        
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        
        GUILayout.Label("Skill 1: Level "+PlayerPrefs.GetInt("Skill1Level"), GUI.skin.FindStyle("PlainText"));
        if ((GUILayout.Button("Buy: 100 Gold"))&&(PhotonNetwork.player.GetScore()>=100))
        {
            int skill = PlayerPrefs.GetInt("Skill1Level") + 1;
            PlayerPrefs.SetInt("Skill1Level", skill);
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
            int skill = PlayerPrefs.GetInt("Skill2Level") + 1;
            PlayerPrefs.SetInt("Skill2Level", skill);
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
            int skill = PlayerPrefs.GetInt("Skill3Level") + 1;
            PlayerPrefs.SetInt("Skill3Level", skill);
            PhotonNetwork.player.AddScore(-300);
            Debug.Log("Bought Skill 3");

        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Heal 10 HP", GUI.skin.FindStyle("PlainText"));
        if ((GUILayout.Button("Buy: 10 Gold")) && (PhotonNetwork.player.GetScore() >= 5)&&(PlayerPrefs.GetInt("HP")+10<=maxHp))
        {
            int skill = PlayerPrefs.GetInt("HP") + 10;
            PlayerPrefs.SetInt("HP", skill);
            PhotonNetwork.player.AddScore(-5);
            Debug.Log("Bought 10 HP");

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
