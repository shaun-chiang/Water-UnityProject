using UnityEngine;
using System.Collections;

//Player Shot

public class Shot2 : MonoBehaviour {
	public int laserSpeed;
	public int dmg;
	Vector3 dir;
	public bool isEnemy = false;
	private int id = 0;
	public int passThroughCount = 1;
	public float bulletTime = 3;
	float timer = 0;

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		transform.Rotate(new Vector3(0, 0, -90));
		Destroy(gameObject, 3);
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
		rb.velocity = (transform.right * laserSpeed);
		/*timer += Time.deltaTime;
		if (timer >= bulletTime) {			

			Destroy (GetComponent<Collider2D> ());
		}*/
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
				//Debug.LogError ("Not ignoring");
				GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				Destroy (this.GetComponent<Collider2D> ());
				//shot.enabled = false;
				laserSpeed = 0;
				//StartCoroutine (shotwait ());


			} else  {
				GetComponent<Animator> ().SetBool ("isSuccessfulhit", false);

				Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), otherCollider);

				//Debug.LogError ("Ignoring");

				passThroughCount--;
				dmg = dmg / 2;
				//StartCoroutine (shotwait ());

			
			} 




		}
	}



	/*void OnCollisionExit2D(Collision2D otherCollision)
	{
		WeaponScript ws = otherCollision.gameObject.GetComponent<WeaponScript>();
		if (ws == null)
		{

			if (otherCollision.gameObject.tag == "Enemy") {
				//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				Destroy (this.GetComponent<Collider2D> ());
				Debug.LogError ("destroying");
				//shot.enabled = false;
				laserSpeed = 0;
				StartCoroutine (shotwait ());


			} else {
				Debug.LogError ("Exit case - not Enemy");
			}


		}

	}
	*/


	void OnTriggerExit2D(Collider2D otherCollider)
	{
		WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
		if (ws == null)
		{

			if (passThroughCount<=0) {
				StartCoroutine (shotwait ());

				//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				//Destroy (this.GetComponent<Collider2D> ());

				//shot.enabled = false;
				//aserSpeed = 0;


				//GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				//StartCoroutine (shotwait ());


			} 
				
				
		}

	}

	

	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(4f);
		Destroy(gameObject);
	}


}
