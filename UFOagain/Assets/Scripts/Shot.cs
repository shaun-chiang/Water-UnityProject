using UnityEngine;
using System.Collections;

//Player Shot

public class Shot : MonoBehaviour {
    public int laserSpeed;
    public int dmg;
    Vector3 dir;
    public bool isEnemy = false;

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        //transform.Rotate(new Vector3(0, 0, -90));
        Destroy(gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    void FixedUpdate()
    {

        print("HHEKSF");
        rb.velocity = (transform.right * laserSpeed);


    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }


}
