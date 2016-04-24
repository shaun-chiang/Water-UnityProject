using UnityEngine;
using System.Collections;

public class ExplosiveCharge : MonoBehaviour
{
    public int PrefabID;

    public int dmg = 10;

    private Rigidbody2D rb;
    private int id = 0;
    public int blastRadius = 10;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource[] sounds;



    void Start()
    {

        rb = this.GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, -90));
        rb.velocity = (transform.right * 2);
        sounds = GetComponents<AudioSource>();
        audio1 = sounds[0];
        audio2 = sounds[1];
        StartCoroutine(shotwait());
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        /*if (other.gameObject.tag=="Enemy")
		{
			//EnemyHealth hscript =other.gameObject.GetComponent<EnemyHealth>();
			//hscript.Damage(dmg);
			GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
			audio2.Play();

			radialAoe(this.GetComponent<CircleCollider2D>());

			Destroy(this.gameObject,1);
			//StartCoroutine(shotwait());
		}*/
    }

    public int getId()
    {
        return this.id;
    }

    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(3f);
        radialAoe(this.GetComponent<CircleCollider2D>());
        GetComponent<Animator>().SetBool("isSuccessfulhit", true);
        audio2.Play();
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    void radialAoe(CircleCollider2D coll)
    {
        Vector2 center = coll.transform.position;
        //Debug.LogError (center);

        //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //foreach(GameObject enemy in enemies) {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, blastRadius);

        for (int i = 0; i < hitColliders.Length; i++)
        {

            EnemyHealth escript = hitColliders[i].gameObject.GetComponent<EnemyHealth>();

            if (escript != null)
            {
                Debug.Log("dmg: " + dmg);
                escript.Damage(dmg, new Vector2(1, 1));
            }

            if (PrefabID != hitColliders[i].gameObject.GetInstanceID())
            {
                HealthScript hs = hitColliders[i].gameObject.GetComponent<HealthScript>();
                if (hs != null)
                {

                    hs.AdjustHealth(dmg * -1);
                }


            }

           

        }


    }


}


