using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    public Rigidbody2D laserShotPrefab;

    public float rof = 0.25f;
    private float cooldown;

	// Use this for initialization
	void Start () {

        cooldown = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
	}

    public void Attack()
    {
        if (canAttack())
        {
            cooldown = rof;
            var laserShotInstance = Instantiate(laserShotPrefab, transform.position, transform.rotation) as Rigidbody2D;
            
            //laserShotInstance.velocity = transform.forward * 20;

           // LaserShotMove move = laserShotInstance.GetComponent<LaserShotMove>();
          //  if (move != null)
           // {
            //    move.setDir(transform.forward);
           // }
        }
    }

    public bool canAttack()
    {
        if (cooldown <= 0f)
        return true;
        else { return false; }
    }
}
