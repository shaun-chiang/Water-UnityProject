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
            Debug.Log("In the shop!");
            GUI.Window(0, new Rect(120, 55, 250, 210), WindowFunction, "Shop!!");

        }
       
    }
    private void WindowFunction(int id)
    {
        GUILayout.Space(37);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Do you really want to quit?", GUI.skin.FindStyle("PlainText"));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Quit to Main Menu"))
        {
            Debug.Log("IM QUITTING!!!!!!!!");
            PlayerPrefs.SetString("NextScene", "Main Menu");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Back to game"))
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
