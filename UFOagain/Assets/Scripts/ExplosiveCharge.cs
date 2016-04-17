using UnityEngine;
using System.Collections;

public class ExplosiveCharge : MonoBehaviour {

    public int dmg = 10;
    public int throwForce = 7;

	private Rigidbody2D rb;
	private int id = 0;
	public int blastRadius= 10;
	public AudioSource audio1;
	public AudioSource audio2;
	public AudioSource[] sounds;


	void Start ()
	{
		rb = this.GetComponent<Rigidbody2D>();
		transform.Rotate(new Vector3(0, 0, -90));
		rb.velocity = (transform.right * throwForce);
		sounds = GetComponents<AudioSource>();
		audio1 = sounds[0];
		audio2 = sounds[1];
	}

	void FixedUpdate ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		

		if (other.gameObject.tag=="Enemy")
		{
			//EnemyHealth hscript =other.gameObject.GetComponent<EnemyHealth>();
			//hscript.Damage(dmg);
			GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
			audio2.Play();

			radialAoe(this.GetComponent<CircleCollider2D>());

			Destroy(this.gameObject,1);
			//StartCoroutine(shotwait());
		}
	}

	public int getId()
	{
		return this.id;
	}

	IEnumerator shotwait()
	{
		yield return new WaitForSeconds(13);
		Destroy(gameObject);
	}

	void radialAoe(CircleCollider2D coll ) {
		Vector2 center = coll.offset;

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