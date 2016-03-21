using UnityEngine;
using System.Collections;
using System;


public class CameraFollowerScript : MonoBehaviour {
	Transform target;


	void Start () {
		


		
	}

	// Update is called once per frame
	void FixedUpdate () {
		try{
		target = GameObject.FindGameObjectWithTag ("player1").transform;
		transform.position = target.position ;
		}

		catch(Exception ex){
			Debug.Log (ex);
		}
		
	}


}