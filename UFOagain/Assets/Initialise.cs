using UnityEngine;
using System.Collections;

public class Initialise : MonoBehaviour {
    public Texture WaterLogo;
	// Use this for initialization
	void Start () {
        StartCoroutine(Example());
    
	
	}
    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.5f);
        print(Time.time);
        PlayerPrefs.DeleteAll();
 
        PhotonNetwork.LoadLevel("Main Menu");
    }
    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / 480.0f, Screen.height / 320.0f, 1));
        GUI.DrawTexture(new Rect(193, 70, 87, 162), WaterLogo);

    }
	
}
