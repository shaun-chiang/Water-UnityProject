using UnityEngine;
using System.Collections;

//Player Shot

public class Shot_blizzard : MonoBehaviour
{
    public int PrefabID;
    private float laserSpeed = 1;
    private int dmg = 10;
    Vector3 dir;
    public bool isEnemy = false;
    private int id = 0;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        this.gameObject.AddComponent<BoxCollider2D>();

        this.GetComponent<BoxCollider2D>().isTrigger = true;

        rb = this.GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f));
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
        laserSpeed += 0.1f;
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
            GetComponent<Animator>().SetBool("isSuccessfulhit", true);
            if (otherCollider.gameObject.tag == "Enemy")
            {

                EnemyHealth escript = otherCollider.gameObject.GetComponent<EnemyHealth>();


                escript.Damage(dmg, new Vector2(3, 3));

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


