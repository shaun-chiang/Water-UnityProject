using UnityEngine;
using System.Collections;


//Player Shot

public class Shot : MonoBehaviour
{
	public int PrefabID;
    public int laserSpeed;
    public int dmg;
    public int range = 1;
    public float clipdur = 0.75f;

    //fatso acid
    public bool isFatso = false;
    private Vector2 targetPos;
    private float aoeRange = 1.3f;
    //end fatso

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
        if (isFatso)
        {
            laserSpeed = laserSpeed * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFatso)
        {
            if (Vector2.Distance(transform.position, targetPos) < 1 || Vector2.Distance(startpos, transform.position) > range)
            {
                GetComponent<Animator>().SetBool("isSuccessfulhit", true);
                Destroy(GetComponent<Collider2D>());
                //shot.enabled = false;
                laserSpeed = 0;
                AOEFatso();
                StartCoroutine(shotwait());
                
            }
        }

        else if (Vector2.Distance(startpos, transform.position) > range)
        {
            Destroy(gameObject);
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
        
        if (!isEnemy)
        {
            WeaponScript ws = otherCollider.GetComponent<WeaponScript>();
            FireballAOEScript faoe = GetComponent<FireballAOEScript>();
			if (ws == null) {
				GetComponent<Animator> ().SetBool ("isSuccessfulhit", true);
				Destroy (GetComponent<Collider2D> ());
				//shot.enabled = false;
				laserSpeed = 0;
				if (faoe != null) {
					faoe.AOE ();
				}
				StartCoroutine (shotwait ());
			} else {
//				Debug.LogError (PrefabID);
				if (PrefabID != otherCollider.gameObject.GetInstanceID ()) {
					Debug.LogError (PrefabID+"   shot1");
					HealthScript hs = otherCollider.GetComponent<HealthScript> ();
					if (hs != null) {

						hs.AdjustHealth (dmg * -1);
					}


				}
			}
        }

        
    }

    IEnumerator shotwait()
    {
        yield return new WaitForSeconds(clipdur);
        Destroy(gameObject);
    }

    //fatso acid
    public void setTargetPos(Vector2 tp)
    {
        targetPos = tp;
    }

    private void AOEFatso()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, aoeRange);
        for (int i = 0; i < targets.Length; i++)
        {
            HealthScript hs = targets[i].gameObject.GetComponent<HealthScript>();
            if (Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < aoeRange)
            {
                Debug.Log("hihihohohohoihih");
                if (hs != null)
                {
                    if (!hs.GetInvin())
                    {
                        hs.AdjustHealth(-dmg);
                        //Debug.Log("hihihohohohoihih" + hs.hp);  
                    }
                }
            }
        }
    }

    //end fatso
}
