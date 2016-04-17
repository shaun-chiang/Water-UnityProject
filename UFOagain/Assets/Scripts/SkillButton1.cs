using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButton1 : MonoBehaviour {
    public Sprite gunner1;
    public Sprite mage1;
    public Sprite archer1;
    public Sprite paladin1;

	// Use this for initialization
	void Start () {
	    if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {
            gameObject.GetComponent<Image>().sprite = gunner1;
        }

        else if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {
            gameObject.GetComponent<Image>().sprite = mage1;
        }

        else if (PlayerPrefs.GetString("Class").Equals("Archer"))
        {
            gameObject.GetComponent<Image>().sprite = archer1;
        }

        else if (PlayerPrefs.GetString("Class").Equals("Paladin"))
        {
            gameObject.GetComponent<Image>().sprite = paladin1;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
