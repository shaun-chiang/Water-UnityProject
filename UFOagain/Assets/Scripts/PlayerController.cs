using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : Photon.PunBehaviour {
    Rigidbody2D rb;
    public float speed;
    //public Rigidbody2D laserShotInstance;
    public int y_rotate = -1;
    private SpriteRenderer circle;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y*y_rotate, transform.localScale.z);
        circle = GetComponentsInChildren<SpriteRenderer>()[1];
        circle.color = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
        if (PhotonView.Get(this).isMine)
        {
            bool isSecondary1 = CrossPlatformInputManager.GetButton("Secondary");
            // Debug.Log(isSecondary1);
            bool isShooting = CrossPlatformInputManager.GetButton("Shoot");
            if (isShooting)
            {
                WeaponScript ws = GetComponent<WeaponScript>();
                if (ws != null)
                {
                    ws.Attack();
                }
            }

            if (isSecondary1)
            {
                WeaponScript ws = GetComponent<WeaponScript>();
                if (ws != null)
                {
                    ws.Secondary1();
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
                GetComponent<Animator>().SetBool("isWalking", true);
                transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
                //transform.eulerAngles.Set(0, 0, transform.eulerAngles.z);
                rb.angularVelocity = 0;
            }

            else
            {
                GetComponent<Animator>().SetBool("isWalking", false);
            }

            //float input = Input.GetAxis("Vertical");
            //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
            //rb.AddForce(movement * speed);
            //transform.position += movement * speed;
        }
    }
}
