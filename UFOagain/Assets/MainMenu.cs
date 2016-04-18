using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public GUISkin Skin;
    public Texture logoTexture;

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
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }
    private void WindowFunction(int id)
    {

        Rect content = new Rect(28, 90, 435, 320);
        GUILayout.BeginArea(content);
        GUI.DrawTexture(new Rect(143, 0, 150, 162), logoTexture);
        GUILayout.Space(165);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Start Game", GUILayout.Width(125)))
        {
            Debug.Log("Hey! Let's start the game!");
            PhotonNetwork.LoadLevel("NetworkLobby");
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Help", GUILayout.Width(75)))
        {
            Debug.Log("Help!");
            PhotonNetwork.LoadLevel("HelpScreen");
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.EndArea();


    }


}
