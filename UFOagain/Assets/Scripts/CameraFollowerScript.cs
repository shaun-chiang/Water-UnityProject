using UnityEngine;
using System.Collections;

public class CameraFollowerScript : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
       // player = GameObject.FindGameObjectWithTag("Player");
        //offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            offset = transform.position - player.transform.position;
        }
        else {
            transform.position = player.transform.position + offset;
        }

	}


}
