using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public int maxHp = 100;
    public int hp = 2;
    public float playerRecoveryNo = 3f;
    public float pushbackForce = 50;

    float playerRecovery = 0f;
    bool isInvin = false;

    public Image healthBar;
    public Image bgHealthBar;
    public GameObject canvas;
    Image newImage;
    Image newBgImage;

    // Use this for initialization
    void Start () {
        GameObject newCanvas = Instantiate(canvas) as GameObject;
        newBgImage = Instantiate(bgHealthBar);
        newBgImage.transform.SetParent(newCanvas.transform, false);
        newImage = Instantiate(healthBar);
        newImage.transform.SetParent(newCanvas.transform, false);
        UpdateHpBar();
    }
	
	// Update is called once per frame
	void Update () {
	    if (playerRecovery > 0)
        {
            playerRecovery -= Time.deltaTime;
        }
	}

    
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();
        if (eh != null)
        {
            if (playerRecovery <= 0 && !isInvin)
            {
                Damage(5);
                //Push back player
                Vector3 pointforce = other.contacts[0].point;
                Vector3 dir = pointforce - transform.position;
                dir = -dir.normalized;
                var force = 30;
                dir = dir * force;
                GetComponent<Rigidbody2D>().AddForce(dir, ForceMode2D.Impulse);
            }
               
        }
    } 
    

    public void Damage(int damage)
    {
        playerRecovery = playerRecoveryNo;
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject.GetComponent<Collider2D>());
            GetComponent<Animator>().SetBool("isDead", true);
            Destroy(gameObject.GetComponent<PlayerController>());
            StartCoroutine(wait());
        }
        else
        {
            isInvin = true;
            StartCoroutine(flash());
        }

        UpdateHpBar();
    }

    void UpdateHpBar()
    {
        newImage.fillAmount = (float)hp / maxHp;
        //newImage.color = Color.Lerp(Color.red, Color.green, (float)hp / maxHp);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator flash()
    {
        for (int i = 0; i < playerRecoveryNo/0.2; i++)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<SpriteRenderer>().enabled = true;
        isInvin = false;
    }
}

