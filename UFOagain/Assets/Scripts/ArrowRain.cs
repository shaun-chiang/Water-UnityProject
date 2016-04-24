using UnityEngine;
using System.Collections;

public class ArrowRain : MonoBehaviour {
	public int PrefabID;
	public int dmg=10;

	private Rigidbody2D rb;
	//private GameObject go;

	private int id = 0;
	public int blastRadius= 2;
	int amt = 1;
	Animator anim;
	public float castTime=3f;
	//float spreadAngle = Random.Range(10f,90f);
	bool go = true;
	int count=0;

	void Start ()
	{
		
		rb = this.GetComponent<Rigidbody2D>();
		//rb.MovePosition (Random.insideUnitCircle * 1);
		transform.Rotate(new Vector3(0, 0, -90));
		//rb.velocity = (transform.right * 2);
		GetComponent<Animator> ().Play ("ArrowRainAnim");
        radialAoe(this.GetComponent<CircleCollider2D>());
        /*for (int i = 0; i <= 5; i++) {
			//rb.MovePosition (Random.insideUnitCircle * 1);
			anim = GetComponent<Animator> ();
			anim.bodyPosition = (Random.insideUnitCircle * 10);
			anim.Play ("ArrowRainAnim");
		}*/

        //GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
        //radialAoe (this.GetComponent<CircleCollider2D> ());
    }


	void Update(){
		

	}
	void FixedUpdate ()
	{
		rb.velocity = (Random.insideUnitCircle*blastRadius);
		//radialAoe (this.GetComponent<CircleCollider2D> ());

		Destroy (this.gameObject,castTime);
	}

	void LateUpdate(){
		if(go){
		rb.velocity = (Random.insideUnitCircle*0);
			GameObject obj = (GameObject)Instantiate (rb.gameObject, transform.position+new Vector3(Random.Range(blastRadius*-1,blastRadius),Random.Range(blastRadius*-1,blastRadius),0), transform.rotation);

		Destroy (obj.GetComponent<ArrowRain> ());
		StartCoroutine(shotwait());
		obj.GetComponent<Animator> ().Play ("ArrowRainAnim");
		count++;
		Destroy (obj, castTime);

			if (count == 20) {
				go = false;
			}
		}

	}




	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.LogError (other);
		//Debug.LogError ("in ontriggerenter");
		//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
		//radialAoe (this.GetComponent<CircleCollider2D> ());
	}

	public int getId()
	{
		return this.id;
	}

	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(13f);

		//Destroy(gameObject);
	}

	void radialAoe(CircleCollider2D coll ) {
		Vector2 center =  coll.transform.position;

		//GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//foreach(GameObject enemy in enemies) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, blastRadius);

		foreach(Collider2D enemy in hitColliders) {

			EnemyHealth escript = enemy.gameObject.GetComponent<EnemyHealth>();

			if (escript != null) {
				escript.Damage (dmg, new Vector2 (1, 1));
			} else {
				if (PrefabID != enemy.gameObject.GetInstanceID ()) {
					HealthScript hs = enemy.gameObject.GetComponent<HealthScript> ();
					if (hs != null) {
                        Debug.LogError("inside arrowrainaoe");
						hs.AdjustHealth (dmg * -1);
					}


				}
			}

		}


	}

	/*void fireInstantiate(){

		//for (int k = 0; k < 4; k++) {

		//GameObject player = GameObject.FindWithTag ("Player");
		//Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		//GameObject obj = (GameObject)Instantiate(rb.gameObject, new Vector3(200,-200,300), transform.rotation);


		float perBulletAngle = spreadAngle / (amt - 1);
		float startAngle = spreadAngle * -0.5f;

		for (int i = 0; i < amt; i++) {
			GameObject obj = (GameObject)Instantiate (rb.gameObject, transform.position, transform.rotation);
			obj.transform.Rotate (Vector3.forward, startAngle + i * perBulletAngle);
			Destroy (obj.GetComponent<FinalGambit2> ());

			obj.AddComponent<BoxCollider2D> ();
			obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			//obj.GetComponent<BoxCollider2D> ().size = new Vector2 (5000f, 5000f);
			obj.AddComponent<Shot_gambit> ();
			//obj.GetComponent<Shot> ().laserSpeed = 600;


		}



		//}
	}*/


}