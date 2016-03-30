using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WeaponScript : Photon.PunBehaviour {

    public Rigidbody2D laserShotPrefab;
    public GameObject laserShotPrefab1;

    public float rof = 1f;
    private float cooldown;

	// Use this for initialization
	void Start () {
        name = gameObject.name;
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
            GetComponent<Animator>().SetTrigger("attack");
            cooldown = rof;
            GetComponent<PhotonView>().RPC("shotActive", PhotonTargets.AllViaServer); 
            //var laserShotInstance = Instantiate(laserShotPrefab, transform.position, transform.rotation) as Rigidbody2D;
            //var laserShotInstance = PhotonNetwork.Instantiate(laserShotPrefab1.name, transform.position, transform.rotation, 0) as GameObject;

        }
    }
    [PunRPC]
    public void shotActive()
    {
        var laserShotInstance = Instantiate(laserShotPrefab, transform.position, transform.rotation) as Rigidbody2D;
        //var laserShotInstance = PhotonNetwork.Instantiate(laserShotPrefab1.name, transform.position, transform.rotation, 0) as GameObject;
    }

    public bool canAttack()
    {
        if (cooldown <= 0f)
        return true;
        else { return false; }
    }
}
