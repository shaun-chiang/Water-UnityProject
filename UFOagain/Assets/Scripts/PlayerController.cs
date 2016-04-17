using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : Photon.PunBehaviour {
    Rigidbody2D rb;
    public float speed;
    //public Rigidbody2D laserShotInstance;
    public int y_rotate = -1;
    private SpriteRenderer circle;

    //Gunner Skill 1 button
    public Sprite gunner1;
    
    //Gunner

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
            //Secondary attacks
            bool isSecondary1 = CrossPlatformInputManager.GetButton("Secondary");
            bool isSecondary2 = CrossPlatformInputManager.GetButton("Secondary2");
            bool isSecondary3 = CrossPlatformInputManager.GetButton("Secondary3");

            //Basic Shot
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

            if (isSecondary2)
            {
                WeaponScript ws = GetComponent<WeaponScript>();
                if (ws != null)
                {
                    ws.Secondary1();
                }
            }

            if (isSecondary3)
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
        }
    }
}
