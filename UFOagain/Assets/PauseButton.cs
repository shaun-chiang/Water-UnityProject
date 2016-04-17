using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public GUISkin Skin;
    public Texture btnTexture;
    private bool buttonPressed=false;
    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        GUILayout.BeginArea(new Rect(466, 7, 150, 300));
        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(btnTexture,GUI.skin.FindStyle("PlainText")) |(buttonPressed))
        {
            buttonPressed = true;
            GUI.Window(0, new Rect(120, 55, 250, 210), WindowFunction, "Quit?");
            Debug.Log("PAUSE!!!!!!!!");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
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
            buttonPressed = false;
        }
        GUILayout.EndHorizontal();
    }

}
