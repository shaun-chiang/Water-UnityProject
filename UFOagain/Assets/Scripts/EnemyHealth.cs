using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int hp = 2;
    public bool isEnemy = true;

    //used to hit player
    public int dmg = 5;

    private bool firehit= false;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Damage(int damage, Vector2 vel)
    {
        hp -= damage;
        Debug.Log("hp is " + hp);
        if (hp <= 0)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<Collider2D>());
            PhotonNetwork.Instantiate("GoldBars",gameObject.transform.position,Quaternion.identity,0);
            GetComponent<AILerp>().enabled = false;
            GetComponent<Animator>().SetBool("isDead", true);
            StartCoroutine(wait());
        }
        else
        {
            
            GetComponent<Rigidbody2D>().AddForce(vel, ForceMode2D.Force);
            if (firehit)
            {
                StartCoroutine(flameani());
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }


    

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Shot shot = otherCollider.gameObject.GetComponent<Shot>();
        if (shot != null && !shot.isEnemy )
        {
            var force = 50;

            Damage(shot.dmg, otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity * force);
            //Destroy(shot.gameObject);
        }

        HealthScript hs = otherCollider.GetComponent<HealthScript>();
        //if (hs != null)
       // {
       //     GetComponent<Animator>().   
       // }

    } 

    IEnumerator flameani()
    {
        GetComponent<Animator>().SetBool("isFlame", true);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("isFlame", false);
    }

    public void setFirehit(bool hit)
    {
        
        firehit = hit;
    }

}

