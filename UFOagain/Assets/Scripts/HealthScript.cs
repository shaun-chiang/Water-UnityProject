using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public int maxHp = 100;
    public int currHp = 20;
    public float playerRecoveryNo = 3f;
    public float pushbackForce = 50;

    float playerRecovery = 0f;
    bool isInvin = false;

    public SpriteRenderer healthBar;
    public SpriteRenderer healthBarBg;
    private Vector3 healthScale;
    public int barSpriteScale;

    PhotonView pView;

    // Use this for initialization
    void Start()
    {
        pView = GetComponent<PhotonView>();
        if (pView.isMine)
        {
            healthScale = healthBar.transform.localScale;
            UpdateHealthBar();
        }
        else
        {
            healthBar.GetComponent<Renderer>().enabled = false;
            healthBarBg.GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                AdjustHealth(-5);
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

    public void AdjustHealth(int healthChange)
    {
        playerRecovery = playerRecoveryNo;
        currHp += healthChange;

        if (currHp > maxHp)
        {
            currHp = maxHp;
        }
        else if (currHp <= 0)
        {
            currHp = 0;
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

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (pView.isMine)
        {
            healthBar.transform.localScale = new Vector3(healthScale.x * currHp * 0.01f, barSpriteScale, 1);
        }
        else
        {
            healthBar.GetComponent<Renderer>().enabled = false;
            healthBarBg.GetComponent<Renderer>().enabled = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.Destroy(gameObject);
    }

    IEnumerator flash()
    {
        for (int i = 0; i < playerRecoveryNo / 0.2; i++)
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

