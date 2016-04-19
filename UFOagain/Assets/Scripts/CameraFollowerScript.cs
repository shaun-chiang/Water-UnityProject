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
            transform.position = player.transform.position;
            offset = transform.position - player.transform.position;
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, -10f);
            transform.position = newPos;
        }
        else {
            transform.position = player.transform.position + offset;
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, -10f);
            transform.position = newPos;
        }

	}


}
