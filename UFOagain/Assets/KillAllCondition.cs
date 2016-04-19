using UnityEngine;
using System.Collections;

public class KillAllCondition : MonoBehaviour
{
    public GUISkin Skin;
    private bool gamedone = false;

    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));

        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // simple gui for output
        if ((enemies.Length>2))
        {
            gamedone = true;
        }
        if ((enemies.Length==0) && (gamedone))
        {
            GUI.Window(0, new Rect(120, 65, 250, 200), WindowFunction, "Level " + PlayerPrefs.GetString("Level") + " Finished!");
            GUILayout.BeginArea(new Rect(316, 2, 150, 300));
            GUILayout.Label("You Win!");
            GUILayout.EndArea();

        } else { 
        GUILayout.BeginArea(new Rect(316, 2, 150, 300));
        GUILayout.Label(enemies.Length + " enemies left!");
        }
        /*if (GUILayout.Button("new round"))
    {
        this.StartRoundNow();
    }*/
        GUILayout.EndArea();
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
            PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
        }
        GUILayout.EndHorizontal();

        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(3.0f);
        PhotonNetwork.LoadLevel("InBetweenLoadingScenes");
    }
}
