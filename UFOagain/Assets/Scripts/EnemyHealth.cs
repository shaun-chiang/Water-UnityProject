using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int hp = 2;
    public bool isEnemy = true;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            //Destroy(gameObject.GetComponent<PhotonRigidbody2DView>());
            //Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<Collider2D>());
            GetComponent<AILerp>().enabled = false;
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponent<EnemyMove>().isAlive = false;
            StartCoroutine(wait());
            Debug.Log("Enemy dead");
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
            Damage(shot.dmg);
            Destroy(shot.gameObject);
        }

        PlayerController pc = otherCollider.gameObject.GetComponent<PlayerController>();
        if (pc != null)
        {
            Debug.Log("Triggered");
        }
    } 
}

