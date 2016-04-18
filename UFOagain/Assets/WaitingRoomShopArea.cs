using UnityEngine;
using System.Collections;

public class WaitingRoomShopArea : MonoBehaviour
{
    public GUISkin Skin;
    private int playersReady=0;
    private bool readiedUp = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered ready zone");
        playersReady++;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited ready zone");
        playersReady--;
    }
    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));

        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        GUILayout.BeginArea(new Rect(156, 2, 300, 300));
        GUILayout.Label("Base Camp: "+playersReady+"/"+PhotonNetwork.room.playerCount+" players ready at center");
        GUILayout.EndArea();
        if ((playersReady == PhotonNetwork.room.playerCount)|(readiedUp))
        {
            readiedUp = true;
            PhotonNetwork.room.visible = false;
            
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
    }
}
