using UnityEngine;
using System.Collections;

//Player Shot

public class Shot : MonoBehaviour {
    public int laserSpeed;
    public int dmg;
    Vector3 dir;
    public bool isEnemy = false;
    private int id = 0;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        transform.Rotate(new Vector3(0, 0, -90));
        Destroy(gameObject,3);
	}
	
	// Update is called once per frame
	void Update () {
         
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
            GetComponent<Animator>().SetBool("isSuccessfulhit", true);
            Destroy(GetComponent<Collider2D>());
            //shot.enabled = false;
            laserSpeed = 0;
            StartCoroutine(shotwait());
            //Destroy(shot.gameObject);
        }

    }




    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }
}
