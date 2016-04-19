using UnityEngine;
using System.Collections;

public class DivineJudgment: MonoBehaviour {
	public int PrefabID;

	public int dmg=10;

	private Rigidbody2D rb;
	private int id = 0;
	public int blastRadius= 10;
	public float casttime = 5f;
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

	void FixedUpdate ()
	{

		if (bdy != null) {
			StartCoroutine (sleepy (bdy));
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{

		PlayerController pc = other.GetComponent<PlayerController> ();
		if (pc != null) {
			tempspd = pc.speed;
			pc.speed = pc.speed * 2;
		}

		other.gameObject.AddComponent<FixedJoint2D> ().connectedBody = rb;
		//StartCoroutine (sleepy (other));
		bdy = other;
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
			GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);

			if (PrefabID != enemy.gameObject.GetInstanceID ()) {
				HealthScript hs = enemy.gameObject.GetComponent<HealthScript> ();
				if (hs != null) {

					hs.AdjustHealth (dmg * -1);
				}


			}

		}


	}


	IEnumerator sleepy(Collider2D other)
	{
		
		radialAoe (this.GetComponent<CircleCollider2D> ());
		rb.velocity = (transform.right * 2);
		yield return new WaitForSeconds(casttime);
		PlayerController pc = other.gameObject.GetComponent<PlayerController> ();
		pc.speed = tempspd;
			
		Destroy(gameObject);

	}


}