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
    public AudioClip FinalFight;

    public AudioSource source;

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
        if (level==0) //Main menu scene
        {
            Debug.Log("Level 0");
            //play main menu
            //source.Stop();
            //source.clip = MainMenu;
            //source.Play();
           
        } else if (level == 2) //"ongoing" scene
        {
            Debug.Log("Level 2");
            //play stage 1
            source.Stop();
            source.clip = StageOne;
            source.Play();
        }
        //from here, add the relevant level scene and play correct music
    }
	
}