using UnityEngine;
using System.Collections;


public class LavaDamage : MonoBehaviour {
	bool inLava = false;
	HealthScript hscript;
	float timer = 0;
	// set this up in the inspector!
	public float damageTime = 2;
	public int damageAmount = 1;
	GameObject player;

	// Use this for initialization
	void Start () {

		//Debug.Log ("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");

	}	

	// Update is called once per frame
	void Update () {
		

	}

	void OnTriggerEnter2D(Collider2D hit){
		
		if (hit.gameObject.tag == "Enemy"){
			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (),hit);
		}
	
	}

	void OnTriggerStay2D(Collider2D hit)
	{
		HealthScript hscript = hit.gameObject.GetComponent<HealthScript> ();

		if(hit.gameObject.tag == "Player")
		{

			// Damage the player every 'damageTime'
			if(timer >= damageTime)
			{
				timer -= damageTime;

				hscript.AdjustHealth(damageAmount*-1);
			}
			timer += Time.deltaTime;
		}
	}
	void OnTriggerExit2D(Collider2D hit)
	{
		if(hit.gameObject.tag == "Player")
		{
			// Reset the damage timer
			timer = 0;
		}
	}








}
