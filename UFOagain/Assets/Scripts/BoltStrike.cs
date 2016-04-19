using UnityEngine;
using System.Collections;

//Player Shot

public class BoltStrike : MonoBehaviour {
	public int PrefabID;
	public int laserSpeed ;
	public int dmg;
	Vector3 dir;
	public bool isEnemy = false;
	private int id = 0;
	public float casttime = 5f;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		transform.Rotate(new Vector3(0, 0, -90));
		//rb.transform.position = new Vector3 (transform.position.x-1f, transform.position.y + 2.5f);
		Destroy(gameObject,3);

	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		rb.velocity = (transform.right * laserSpeed);
		if (laserSpeed > 0) {
			laserSpeed--;
			
		}

	}

	void OnBecomeInvisible()
	{
		Destroy(gameObject);
	}

	public int getId()
	{
		return this.id;
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{		
		WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
		if (ws != null) {
			otherCollider.gameObject.AddComponent<HingeJoint2D> ().connectedBody = rb;
			//otherCollider.GetComponent<HingeJoint2D> ().anchor = new Vector2 (transform.position.x + 5f, transform.position.y);
			//rb.transform.SetParent (otherCollider.transform);
			//transform.root.parent = otherCollider.transform;
			Debug.LogError (otherCollider);
			GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
			//laserSpeed--;
			//Destroy(GetComponent<Collider2D>(),casttime);
			//shot.enabled = false;
			
			
			//Destroy(shot.gameObject);

		}

		if (otherCollider.gameObject.tag == "Enemy") {
			EnemyHealth escript = otherCollider.gameObject.GetComponent<EnemyHealth> ();
			escript.Damage (dmg, new Vector2 (1, 1));

		} else {
			if (PrefabID != otherCollider.gameObject.GetInstanceID ()) {
				HealthScript hs = otherCollider.gameObject.GetComponent<HealthScript> ();
				if (hs != null) {
					
					hs.AdjustHealth (dmg * -1);
				}


			}
		}
	}




	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(2f);

	}
}
