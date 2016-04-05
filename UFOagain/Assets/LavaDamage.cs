using UnityEngine;
using System.Collections;


public class LavaDamage : MonoBehaviour {
	bool inLava = false;
	HealthScript hscript;

	// Use this for initialization
	void Start () {
		hscript = GetComponent<HealthScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		//OnTriggerEnter ();	
	

	}



	void OnTriggerExit(Collider obj){ inLava = false; }

	void OnGUI(){ 
		if (inLava) {
			hscript.Damage (1);

			}
		}


	void OnTriggerEnter(Collider obj){
		if (obj.tag == "Player") {
			inLava = true;
		} else {
			inLava = false;
		}
	}




}
