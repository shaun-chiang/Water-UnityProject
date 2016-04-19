using UnityEngine;
using System.Collections;

//Player Shot

public class Blizzard: MonoBehaviour {
	public int PrefabID;
	public int laserSpeed;
	public int dmg;
	Vector3 dir;
	public bool isEnemy = false;
	private int id = 0;
	int amt=5;
	float i=0.1f;
	Rigidbody2D[] rbarray;
	bool go = false;
	private Vector3 shotPosition;
	private Vector3 shotPosition2;
	private Vector3 shotPosition3;
	float spreadAngle =72;



	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		//go = false;
		transform.Rotate(new Vector3(0, 0, -90));
		//rb.transform.position = new Vector3 (transform.position.x, transform.position.y + 2.5f);
		fireInstantiate ();
		//StartCoroutine (sleepy());

		//go = true;
		/*for (int i = 0; i < amt; i++) {
			//Rigidbody2D clone = (Rigidbody2D)Instantiate (rb, transform.position, transform.rotation);
			Rigidbody clone = (Rigidbody) Instantiate(rb, transform.position, transform.rotation);
			clone.velocity = (transform.right * laserSpeed);
		}	*/






		Destroy(gameObject,0.1f);
	}

	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate()
	{


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
		//if (otherCollider.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D> (), otherCollider.GetComponent<BoxCollider2D> ());
		

		laserSpeed = 0;
		StartCoroutine(shotwait());
		//Destroy(shot.gameObject);


	}




	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(13);
		Destroy(gameObject);
	}

	void fireInstantiate(){

		//for (int k = 0; k < 4; k++) {

		//GameObject player = GameObject.FindWithTag ("Player");
		//Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		//GameObject obj = (GameObject)Instantiate(rb.gameObject, new Vector3(200,-200,300), transform.rotation);


		float perBulletAngle = spreadAngle / (amt - 1);
		float startAngle = spreadAngle * -0.5f;

		for (int i = 0; i < amt; i++) {
			GameObject obj = (GameObject)Instantiate (rb.gameObject, transform.position, transform.rotation);
			obj.transform.Rotate (Vector3.forward, startAngle + i * perBulletAngle);
			//Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(),obj.GetComponent<Collider2D>());
			Destroy (obj.GetComponent<Blizzard> ());

			obj.AddComponent<BoxCollider2D> ();
			obj.GetComponent<BoxCollider2D> ().isTrigger = true;
			obj.GetComponent<BoxCollider2D> ().size = new Vector2 (0.5f, 0.5f);
			obj.AddComponent<Shot_blizzard> ();
			obj.GetComponent<Shot_blizzard> ().PrefabID = PrefabID;
			//obj.GetComponent<Shot> ().laserSpeed = 600;


		}



		//}
	}
	IEnumerator sleepy(GameObject obj)
	{

		yield return new WaitForSeconds(3f);


		obj.AddComponent<BoxCollider2D> ();
		obj.GetComponent<BoxCollider2D> ().isTrigger = true;
		obj.GetComponent<BoxCollider2D> ().size = new Vector2 (0.5f, 0.5f);
		obj.AddComponent<Shot_blizzard> ();
		yield return new WaitForSeconds(3f);


	}


}