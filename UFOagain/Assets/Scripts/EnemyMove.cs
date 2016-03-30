using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    private GameObject myTarget;
    private Vector3 targetPos;
    private Rigidbody2D rb;
    private GameObject[] players;
    private float playerLock = 0f;

    public float mySpeed; 
    public bool isAlive = true;

    
	// Use this for initialization
	void Start () {
        myTarget = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {
        if (playerLock <= 0)
        {
            myTarget = findNearestPlayer();
        }
        playerLock -= Time.deltaTime;
        targetPos = myTarget.transform.position;
        
	}

    void FixedUpdate()
    {
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
        }
    }

    private GameObject findNearestPlayer()
    {
        playerLock = 2f;
        players = GameObject.FindGameObjectsWithTag("Player");
        float dist = Mathf.Infinity;
        GameObject closest = null;
        foreach (GameObject g in players){
            Vector3 diff = transform.position - g.transform.position;
            float currDist = diff.sqrMagnitude;
            if (currDist < dist)
            {
                dist = currDist;
                closest = g;
            }
        }
        return closest;
    } 



}
