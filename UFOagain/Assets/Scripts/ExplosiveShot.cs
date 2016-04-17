using UnityEngine;
using System.Collections;

public class ExplosiveShot : MonoBehaviour {

	public int dmg=10;
	public int laserSpeed;
	private Rigidbody2D rb;
	private int id = 0;
	public int blastRadius= 10;
	//public AudioSource audio1;



	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
		transform.Rotate(new Vector3(0, 0, -90));
		rb.velocity = (transform.right * 2);
		//sounds = GetComponents<AudioSource>();

	}

	void FixedUpdate ()
	{
		rb.velocity = (transform.right * laserSpeed);

		StartCoroutine (shotwait ());

	}

	void OnTriggerEnter2D(Collider2D other) 
	{


		if (other.gameObject.tag == "Enemy") {
			//EnemyHealth hscript =other.gameObject.GetComponent<EnemyHealth>();
			//hscript.Damage(dmg);
			GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);

			//audio1.Play();

			radialAoe (this.GetComponent<CircleCollider2D> ());

			Destroy (this.gameObject, 1);
			//StartCoroutine(shotwait());
		} else if (other.gameObject.tag == "Untagged") {
			
			laserSpeed = 0;

		}
	}

	public int getId()
	{
		return this.id;
	}

	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(2f);
		GetComponent<Animator> ().SetBool ("timeup", true);
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}

	void radialAoe(CircleCollider2D coll ) {
		Vector2 center = coll.transform.position;

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//foreach(GameObject enemy in enemies) {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, blastRadius);

		foreach(Collider2D enemy in hitColliders) {

			EnemyHealth escript = enemy.gameObject.GetComponent<EnemyHealth>();

			if (escript != null) {
				escript.Damage (dmg,new Vector2(1,1));
			}

		}


	}


}