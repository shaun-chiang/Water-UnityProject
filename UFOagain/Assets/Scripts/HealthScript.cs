using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public int maxHp;
    public int currHp;
    private int newHp;
    public float playerRecoveryNo = 3f;
    public float pushbackForce = 50;

    float playerRecovery = 0f;
    bool isInvin = false;

    public SpriteRenderer healthBar;
    public SpriteRenderer healthBarBg;
    private Vector3 healthScale;
    public int barSpriteScale;

    float originalValue;
    float newValue;
    float difference;

    PhotonView pView;

    // Use this for initialization
    void Start()
    {
        
        if (gameObject.name.StartsWith("Paladin"))
        {
            currHp = PlayerPrefs.GetInt("HP");
            maxHp = 125;
        } else if (gameObject.name.StartsWith("Mage"))
        {
            currHp = PlayerPrefs.GetInt("HP");
            maxHp = 75;
        }
        else if (gameObject.name.StartsWith("Gunner"))
        {
            currHp = PlayerPrefs.GetInt("HP");
            maxHp = 75;
        }
        else if (gameObject.name.StartsWith("Archer"))
        {
            currHp = PlayerPrefs.GetInt("HP");
            maxHp = 100;
        }
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
        
        currHp = PlayerPrefs.GetInt("HP");
        

        UpdateHealthBar();

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
        if (pView.isMine)
        {
            playerRecovery = playerRecoveryNo;
            newHp = currHp + healthChange;

            PlayerPrefs.SetInt("HP", newHp);

            if (currHp > maxHp)
            {
                newHp = maxHp;

                PlayerPrefs.SetInt("HP", newHp);


            }
            else if (currHp <= 0)
            {
                newHp = 0;

                PlayerPrefs.SetInt("HP", newHp);

                Destroy(gameObject.GetComponent<Collider2D>());
                GetComponent<Animator>().SetBool("isDead", true);
                Destroy(gameObject.GetComponent<PlayerController>());
                //PhotonNetwork.LoadLevel("GameOver");
                StartCoroutine(wait());
            }
            else
            {
                isInvin = true;
                StartCoroutine(flash());
            }

            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        if (pView.isMine)
        {
            originalValue = healthBar.bounds.min.x;
            healthBar.transform.localScale = new Vector3(healthScale.x * currHp * 1.0f/maxHp, barSpriteScale, 1);
            newValue = healthBar.bounds.min.x;
            difference = newValue - originalValue;
            healthBar.transform.Translate(new Vector3(-difference, 0f, 0f));
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

    public bool GetInvin()
    {
        return isInvin;
    }
}

