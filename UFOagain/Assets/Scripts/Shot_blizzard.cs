using UnityEngine;
using System.Collections;

//Player Shot

public class Shot_blizzard : MonoBehaviour
{
    public int PrefabID;
    private float laserSpeed = 1;
    public int dmg = 10;
    Vector3 dir;
    public bool isEnemy = false;
    private int id = 0;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.Log("Circle collider being added to blizzard");
            CircleCollider2D cir = gameObject.AddComponent<CircleCollider2D>();
            cir.isTrigger = true;
            cir.radius = 0.39f;
        }
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
        //rb.velocity = (transform.right * laserSpeed);
        //laserSpeed += 0.1f;
        rb.transform.position = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 0.19f);
        for (int i = 0; i < hitColliders.Length; i++)
        {

            EnemyHealth escript = hitColliders[i].gameObject.GetComponent<EnemyHealth>();

            if (escript != null)
            {
                Debug.Log("dmg: " + dmg);
                escript.Damage(dmg, new Vector2(1, 1));
            }
            //rb.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), transform.position.y), ForceMode2D.Impulse);
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
        //if (otherCollider.gameObject.tag == "Player") {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), otherCollider.GetComponent<Collider2D>());
        


        //}
        WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
        if (ws == null)
        {

            //Physics2D.IgnoreCollision (this.GetComponent<BoxCollider2D> (),otherCollider.GetComponent<BoxCollider2D> ());
            //GetComponent<Animator>().SetBool("isSuccessfulhit", true);
            if (otherCollider.gameObject.tag == "Enemy")
            {

                EnemyHealth escript = otherCollider.gameObject.GetComponent<EnemyHealth>();

                Debug.Log("Triggeringingingignigng");
                escript.Damage(dmg, new Vector2(0, 0));

            }
            else {

                if (PrefabID != otherCollider.gameObject.GetInstanceID())
                {
                    HealthScript hs = otherCollider.gameObject.GetComponent<HealthScript>();
                    if (hs != null)
                    {

                        hs.AdjustHealth(dmg * -1);
                    }


                }
            }

            Destroy(GetComponent<Collider2D>());
            //shot.enabled = false;
            //laserSpeed = 0;
            //StartCoroutine(shotwait());
            //Destroy(shot.gameObject);
        }
        /*else if (otherCollider.gameObject.tag == "Player") {
           HealthScript hscript = otherCollider.gameObject.GetComponent<HealthScript> ();
           hscript.AdjustHealth (dmg * -1);

       }*/
    }

    //GetComponent<Animator>().SetBool("isSuccessfulhit", true);
    //Destroy(GetComponent<Collider2D>(),3f);
    //shot.enabled = false;
    //laserSpeed = 0;
    //StartCoroutine(shotwait());
    //Destroy(shot.gameObject);







    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }
}


