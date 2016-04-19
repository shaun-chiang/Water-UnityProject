using UnityEngine;
using System.Collections;

//Player Shot

public class HeavensHammer : MonoBehaviour {
	public int PrefabID;
	public int laserSpeed;
	public int dmg;
	Vector3 dir;
	public bool isEnemy = false;
	private int id = 0;
	//public int passThroughCount = 1;
	public float bulletTime = 3;
	float timer = 0;
	bool goj=true;
	Rigidbody2D rb;
	int count=0;
	float offset=0.1f;
	int blastRadius = 2;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		//transform.Rotate(new Vector3(0, 0, -90));
		Destroy(gameObject, 0.1f);
	}

	// Update is called once per frame
	void Update () {
		/*timer += Time.deltaTime;
		if (timer >= bulletTime) {			

			Destroy (this.GetComponent<Collider2D> ());
		}*/

	}

	void FixedUpdate()
	{
		
		/*timer += Time.deltaTime;
		if (timer >= bulletTime) {			

			Destroy (GetComponent<Collider2D> ());
		}*/
	}

	void LateUpdate(){
		if (goj) {
			//for (int j = 0; j < 5; j++) {
			//GameObject go = new GameObject ();
			//go.transform.position = new Vector2 (rb.position.x + j, rb.position.y);
			//go.AddComponent<Animator> ().;
			//go.GetComponent<Animator> ().Play ("PaladinHeavenHammerAnim");
			//}
			//rb.velocity = (Random.insideUnitCircle*0);
			//GameObject obj = (GameObject)Instantiate (rb.gameObject, rb.gameObject.transform.localPosition + new Vector3 (0, offset, 0), transform.rotation);
			GameObject obj = (GameObject)Instantiate (rb.gameObject, transform.position+new Vector3(Random.Range(blastRadius*-1,blastRadius),Random.Range(blastRadius*-1,blastRadius),0), transform.rotation);
			offset += 1f;
			Destroy (obj.GetComponent<HeavensHammer> ());
			Destroy (obj.GetComponent<Rigidbody2D> ());
			Destroy (obj.GetComponent<CircleCollider2D> ());
			StartCoroutine (shotwait ());
			obj.GetComponent<Animator> ().Play ("PaladinHeavenHammerAnim");
			count++;
			Destroy (obj, 3f);
			radialAoe (rb.gameObject.GetComponent<CircleCollider2D> ());
			if (count == 8) {
				goj = false;

			}

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
		WeaponScript ws = otherCollider.GetComponent<WeaponScript> ();
		if (ws == null) {
			if (otherCollider.tag != "Enemy") {
				if (PrefabID != otherCollider.GetInstanceID ()) {
					HealthScript hs = otherCollider.gameObject.GetComponent<HealthScript> ();
					if (hs != null) {

						hs.AdjustHealth (dmg * -1);
					}


				}
				//Debug.LogError ("Not ignoring");
				//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				Destroy (this.GetComponent<Collider2D> ());
				//shot.enabled = false;
				laserSpeed = 0;
				//StartCoroutine (shotwait ());




			} else  {
				//GetComponent<Animator> ().SetBool ("isSuccessfulhit", false);
				EnemyHealth escript = otherCollider.gameObject.GetComponent<EnemyHealth>();
				if (escript != null) {
					escript.Damage (dmg,new Vector2(1,1));
				}
				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), otherCollider);

			


			} 




		}
	}



	void radialAoe(CircleCollider2D coll ) {
		Vector2 center =  coll.transform.position;

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

	void OnTriggerExit2D(Collider2D otherCollider)
	{
		WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
		if (ws == null)
		{

			//if (passThroughCount<=0) {
			StartCoroutine (shotwait ());

			//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
			//Destroy (this.GetComponent<Collider2D> ());

			//shot.enabled = false;
			//aserSpeed = 0;


			//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
			//StartCoroutine (shotwait ());


			//} 


		}

	}



	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(4f);
		Destroy(gameObject);
	}


}
