using UnityEngine;
using System.Collections;

public class HelpScreen : MonoBehaviour {
    public GUISkin Skin;

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
        GUILayout.Space(50);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Help is supposed to be here.");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Space(100);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Back", GUILayout.Width(125)))
        {
            Debug.Log("Going back to main menu!");
            PhotonNetwork.LoadLevel("Main Menu");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


    }

}
