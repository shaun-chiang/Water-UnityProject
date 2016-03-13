using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using Photon;

public class PlayerController : PunBehaviour {
    Rigidbody2D rb;
    public float speed;
    //public Rigidbody2D laserShotInstance;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*-1, transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update () {
        if (PhotonView.Get(this).isMine)
        {
            bool isShooting = CrossPlatformInputManager.GetButton("Shoot");
            if (isShooting)
            {
                WeaponScript ws = GetComponent<WeaponScript>();
                Debug.Log("shot invoked");
                if (ws != null)
                {
                    Debug.Log("Go!");
                    ws.Attack();
                }
            }
        }
    }


    void FixedUpdate()
    {
        if (PhotonView.Get(this).isMine)
        {
            Vector3 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
            rb.AddForce(moveVec * speed);


            // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Quaternion rot = Quaternion.LookRotation(moveVec, Vector3.forward);
            if (moveVec.sqrMagnitude > 0.1f)
            {
                transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
                //transform.eulerAngles.Set(0, 0, transform.eulerAngles.z);
                rb.angularVelocity = 0;
            }



            //float input = Input.GetAxis("Vertical");
            //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            //rb.AddForce(movement * speed);
            //transform.position += movement * speed;
        }
    }
}
