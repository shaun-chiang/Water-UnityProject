using UnityEngine;
using System.Collections;

public class HelpScreen : MonoBehaviour {
    public GUISkin Skin;
    public Texture HelpPicture;

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

        GUI.Window(0, content, WindowFunction, "");
    }
    private void WindowFunction(int id)
    {

        Rect content = new Rect(333, 0, 125, 308);
        GUI.DrawTexture(new Rect(52, 110, 300, 182), HelpPicture);
        GUILayout.BeginArea(content);
        GUILayout.Space(100);
        GUILayout.BeginHorizontal();
        
        GUILayout.FlexibleSpace();
        GUILayout.Label("Souls of Betrayal",GUI.skin.FindStyle("BoldOutlineText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" is a Quest Game ", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" where 1-4 heroes", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" must take on the", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label("dungeons - as one.", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" However, they all", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" know that at the ", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label("end, there can only", GUI.skin.FindStyle("PlainText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(25);
        GUILayout.Label(" be one King...", GUI.skin.FindStyle("CursedText"));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Back", GUILayout.Width(105))|Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Going back to main menu!");
            PhotonNetwork.LoadLevel("Main Menu");
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


    }

}
