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
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponent<EnemyMove>().isAlive = false;
            StartCoroutine(wait());
            
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
            if (!shot.isEnemy) 
            {
                Damage(shot.dmg);
                

            }
            Destroy(shot.gameObject);
        }
    }
}

