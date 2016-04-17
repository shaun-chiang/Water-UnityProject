using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

    public static MusicSingleton instance = null;
    public static MusicSingleton Instance
    {
        get { return instance; }
    }

    public AudioClip MainMenu;
    public AudioClip StageOne;
    public AudioClip StageTwo;
    public AudioClip StageThree;
    public AudioClip WaitingRoom;
    public AudioClip FinalFight;
    public int currentsong;
    public AudioSource source;

    void Start()
    {

        currentsong = 1;
    }

    // Use this for initialization
    void Awake () {
        AudioSource sound = gameObject.GetComponent<AudioSource>();
        if ((instance != null)&& (instance!=this)) {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded(int level)
    {
        Debug.Log("Level: "+level);
        Debug.Log("Current: "+currentsong);
        if ((level==1)&&(currentsong!=1)) //Main menu scene
        {
            currentsong = 1;
            //play main menu
            source.Stop();
            source.clip = MainMenu;
            source.Play();
           
        } else if ((level == 6)&&(currentsong!=2)) //waitingroomshop
        {
            currentsong = 2;
            //play stage 1
            source.Stop();
            source.clip = WaitingRoom;
            source.Play();
        }
        else if (((level == 7)|(level == 8)|(level==9))&&(currentsong!=3)) //stage1
        {
            currentsong = 3;
            //play stage 1
            source.Stop();
            source.clip = StageOne;
            source.Play();
        }
        else if (((level == 10) | (level ==11) | (level == 12))&&(currentsong!=4)) //stage1
        {
            currentsong = 4;
            //play stage 2
            source.Stop();
            source.clip = StageTwo;
            source.Play();
        }
        else if (((level == 13) | (level == 14) | (level == 15))&&(currentsong!=5)) //stage1
        {
            currentsong = 5;
            //play stage 1
            source.Stop();
            source.clip = StageThree;
            source.Play();
        }
        else if ((level == 15)&&(currentsong!=6)) //stage1
        {
            currentsong = 6;
            //play stage 1
            source.Stop();
            source.clip = FinalFight;
            source.Play();
        }

        //from here, add the relevant level scene and play correct music
    }
	
}