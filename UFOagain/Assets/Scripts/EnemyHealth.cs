using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int hp = 2;
    public bool isEnemy = true;

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
            //Destroy(gameObject.GetComponent<PhotonRigidbody2DView>());
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<Collider2D>());
            PhotonNetwork.Instantiate("GoldBars",gameObject.transform.position,Quaternion.identity,0);
            GetComponent<AILerp>().enabled = false;
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponent<EnemyMove>().isAlive = false;
            StartCoroutine(wait());
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(vel, ForceMode2D.Force);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


    

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Shot shot = otherCollider.gameObject.GetComponent<Shot>();
        if (shot != null)
        {

            var force = 50;

            Damage(shot.dmg, otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity * force);
            //Destroy(shot.gameObject);
        }

    } 

}

