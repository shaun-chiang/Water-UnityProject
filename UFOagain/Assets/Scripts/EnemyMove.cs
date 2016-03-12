using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private GameObject myTarget;
    private Vector3 targetPos;
    public float mySpeed;
    private Rigidbody2D rb;
    public bool isAlive = true;

	// Use this for initialization
	void Start () {
        myTarget = GameObject.FindGameObjectWithTag("Player1");
        rb = GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {
       
        targetPos = myTarget.transform.position;
        
	}

    void FixedUpdate()
    {
        Debug.Log(isAlive);
        if (isAlive)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, mySpeed);
            // transform.LookAt(myTarget.transform);
            Quaternion rot = Quaternion.LookRotation(myTarget.transform.position - transform.position, Vector3.forward);
            transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
            rb.angularVelocity = 0;
        }

        else
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            print("hellooooo");
        }
    }



}
