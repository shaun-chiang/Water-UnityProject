using UnityEngine;
using System.Collections;

public class levelloader : MonoBehaviour {
    public GUISkin Skin;
    IEnumerator Start()
    {
        Debug.Log("started preload");
        AsyncOperation async = Application.LoadLevelAsync(PlayerPrefs.GetString("NextScene"));
        yield return async;
        Debug.Log("Loading complete");
    }
    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        if (this.Skin != null)
        {
            GUI.skin = this.Skin;
        }
        GUI.TextField(new Rect(366, 250, 50, 30), "Loading...", GUI.skin.FindStyle("PlainText"));
    }
}
