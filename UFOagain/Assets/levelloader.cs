using UnityEngine;
using System.Collections;

public class levelloader : MonoBehaviour {
    public GUISkin Skin;
    private string NextScene;
    void Start()
    {
        int current = PlayerPrefs.GetInt("NextScene") + 1;
        Debug.Log("current: " + current);
        PlayerPrefs.SetInt("NextScene", current);
        int currentlevel = PlayerPrefs.GetInt("NextScene");
        if ((currentlevel==0)|(currentlevel==2)|(currentlevel==4)|(currentlevel==6))
        {
            NextScene = "WaitingRoomShop";
        } else if ((currentlevel == 1))
        {
            int randomNumber = Random.Range(1, 1);
            if (randomNumber==1)
            {
                NextScene = "ongoing";
            }else if (randomNumber == 2)
            {
                NextScene = "Level 1B";
            }
            else if (randomNumber == 3)
            {
                NextScene = "Level 1C";
            }
        }
        else if ((currentlevel == 3))
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                NextScene = "Level 2A";
            }
            else if (randomNumber == 2)
            {
                NextScene = "Level 2B";
            }
            else if (randomNumber == 3)
            {
                NextScene = "Level 2C";
            }
        }
        else if ((currentlevel == 5))
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1)
            {
                NextScene = "Level 3A";
            }
            else if (randomNumber == 2)
            {
                NextScene = "Level 3B";
            }
            else if (randomNumber == 3)
            {
                NextScene = "Level 3C";
            }
        }
        else if ((currentlevel == 7))
        {
            NextScene = "FinalArena";
        }
        //AsyncOperation async = Application.LoadLevelAsync(NextScene);
        //yield return async;
        PhotonNetwork.LoadLevel(NextScene);
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
