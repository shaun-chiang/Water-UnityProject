using UnityEngine;
using System.Collections;

//Player Shot

public class Shot_gambit : MonoBehaviour
{
    public int PrefabID;
    private int laserSpeed = 15;
    private int dmg = 10;
    Vector3 dir;
    public bool isEnemy = false;
    private int id = 0;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //transform.Rotate(new Vector3(0, 0, -90));
        Destroy(gameObject, 3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.velocity = (transform.right * laserSpeed);
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
        if (otherCollider.gameObject.tag == "Enemy")
        {
            EnemyHealth escript = otherCollider.gameObject.GetComponent<EnemyHealth>();


            escript.Damage(dmg, new Vector2(1, 1));

        } /*else if (otherCollider.gameObject.tag == "Player") {
			HealthScript hscript = otherCollider.gameObject.GetComponent<HealthScript> ();
			hscript.AdjustHealth (dmg * -1);

		}*/
        else {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), otherCollider);
            if (PrefabID != otherCollider.gameObject.GetInstanceID())
            {
                HealthScript hs = otherCollider.gameObject.GetComponent<HealthScript>();
                if (hs != null)
                {

                    hs.AdjustHealth(dmg * -1);
                }


            }
        }

        //GetComponent<Animator>().SetBool("isSuccessfulhit", true);
        //Destroy(GetComponent<Collider2D>(),3f);
        //shot.enabled = false;
        //laserSpeed = 0;
        //StartCoroutine(shotwait());
        //Destroy(shot.gameObject);


    }




    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }
}


