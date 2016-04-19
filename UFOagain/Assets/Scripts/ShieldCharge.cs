using UnityEngine;
using System.Collections;

public class ShieldCharge: MonoBehaviour {
	public int PrefabID;
	public int dmg=3;

	private Rigidbody2D rb;
	private int id = 0;
	public int blastRadius= 2;
	public float casttime = 0.1f;
	float tempspd;
	public volatile PlayerController pc;
	Collider2D bdy;

	void Start ()
	{

		rb = this.GetComponent<Rigidbody2D> ();
		//transform.Rotate (new Vector3 (0, 0, -90));
		//rb.velocity = (transform.right * 2);
		//StartCoroutine(sleep());


	}

	void LateUpdate ()
	{
		radialAoe (this.GetComponent<CircleCollider2D> ());
		if (bdy != null) {
			
			StartCoroutine (sleepy (bdy));
			rb.velocity = (transform.right * 1);
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{	
		
		if (other.gameObject.tag == "Player") {
			PlayerController pc = other.GetComponent<PlayerController> ();

			//other.gameObject.AddComponent<HingeJoint2D> ().connectedBody = rb;
			//StartCoroutine (sleepy (other));
			bdy = other;
			if (PrefabID != other.gameObject.GetInstanceID()) {
				HealthScript hs = other.gameObject.GetComponent<HealthScript> ();
				if (hs != null) {

					hs.AdjustHealth (dmg * -1);
				}


			}

		}

		

		if (other.gameObject.tag == "Enemy")  {
			
			EnemyHealth escript = other.gameObject.GetComponent<EnemyHealth> ();
			escript.Damage (dmg, new Vector2 (3, 3));
			Destroy (gameObject);

		}
	}

	public int getId()
	{
		return this.id;
	}

	void radialAoe(CircleCollider2D coll ) {
		Vector2 center = coll.transform.position;
		//Debug.LogError (center);

		//GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//foreach(GameObject enemy in enemies) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, blastRadius);

		foreach(Collider2D enemy in hitColliders) {

			EnemyHealth escript = enemy.gameObject.GetComponent<EnemyHealth>();

			if (escript != null) {
				escript.Damage (dmg,new Vector2(1,1));
			}

		}


	}




	IEnumerator sleepy(Collider2D other)
	{

		//radialAoe (this.GetComponent<CircleCollider2D> ());
		if (other.gameObject.tag=="Player") {
			other.GetComponentInParent<Rigidbody2D> ().AddForce (other.transform.up.normalized * -35, ForceMode2D.Impulse);

			yield return new WaitForSeconds (0);


			Destroy (gameObject);
		}
	}


}