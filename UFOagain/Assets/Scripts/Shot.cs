using UnityEngine;
using System.Collections;

//Player Shot

public class Shot : MonoBehaviour
{
    public int laserSpeed;
    public int dmg;
    public int range = 1;
    Vector3 dir;
    public bool isEnemy = false;
    private int id = 0;
    Vector2 startpos;

    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, -90));
        Destroy(gameObject, 3);
        startpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("PaladinMelee"))
        {
            if (Vector2.Distance(startpos, transform.position) > range)
            {
                Destroy(gameObject);
            }
        }
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
        WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
        if (ws == null)
        {
            if (gameObject.CompareTag("PaladinMelee"))
            {
                Destroy(GetComponent<Collider2D>());
                //shot.enabled = false;
                laserSpeed = 0;
                StartCoroutine(shotwait());
            }
            else
            {
                GetComponent<Animator>().SetBool("isSuccessfulhit", true);
                Destroy(GetComponent<Collider2D>());
                //shot.enabled = false;
                laserSpeed = 0;
                StartCoroutine(shotwait());
            }

        }

    }

    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }
}
