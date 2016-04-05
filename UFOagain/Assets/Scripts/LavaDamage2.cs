using UnityEngine;
using System.Collections;


public class LavaDamage2 : MonoBehaviour {
	bool inLava = false;
	HealthScript hscript;
	float timer = 0;
	// set this up in the inspector!
	public float damageTime = 2;
	public int damageAmount = 1;
	GameObject player;

	// Use this for initialization
	void Start () {
		
		Debug.Log ("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");

	}	

	// Update is called once per frame
	void Update () {
		//OnTriggerEnter ();	

		//OnTriggerExit (this);


	}

	void OnTriggerStay2D(Collider2D hit)
	{
		HealthScript hscript = hit.gameObject.GetComponent<HealthScript>();
		Debug.Log ("hit!!!!!!!!!!!");
		Debug.Log ("Hp"+hscript.hp);

		if(hit.gameObject.tag == "Player")
		{
			
			// Damage the player every 'damageTime'
			if(timer >= damageTime)
			{
				timer -= damageTime;

				hscript.Damage(damageAmount);
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
