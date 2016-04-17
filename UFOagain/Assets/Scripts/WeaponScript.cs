using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WeaponScript : Photon.PunBehaviour {
    //General
    public Rigidbody2D laserShotPrefab;
    public Rigidbody2D secondary1Prefab;
    public Rigidbody2D secondary2Prefab;
    public float rof = 1f;

    //Gunner
        //Explosive Charge
        public int explosiveChargeCount = 3;
        public float rofEC = 5f;
        private float cooldownEC;
        public float rofperCharge = 1f;
        private float cooldownPerCharge = 0f;

        //Skill2

    //Mage
    //Fireball
        public float rofFireball = 5f;
        private float cooldownFireball = 0f;

    //Archer
    

    private float cooldown;


	// Use this for initialization
	void Start () {
        name = gameObject.name;
        cooldown = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
        //Basic Shot
	    if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Gunner 
        //Explosive Charge Cooldown - Place 3 charges then cooldown starts
        if (cooldownEC > 0)
        {
            cooldownEC -= Time.deltaTime;
        }
        
        if (cooldownPerCharge > 0)
        {
            cooldownPerCharge -= Time.deltaTime;
        }

        //Mage 
        //Fireball
        if (cooldownFireball > 0)
        {
            cooldownFireball -= Time.deltaTime;
        }


    }

    public void Secondary1()
    {
        Debug.Log("Secondary: " + PlayerPrefs.GetString("Class"));
        //Gunner 
        //Explosive Charge
        if (PlayerPrefs.GetString("Class").Equals("GunnerIdle"))
        {
            if (cooldownPerCharge <= 0)
            {
                if (explosiveChargeCount > 0 && cooldownEC <= 0f)
                {
                    cooldownPerCharge += rofperCharge;
                    explosiveChargeCount -= 1;
                    if (explosiveChargeCount == 0)
                    {
                        cooldownEC += rofEC;
                        explosiveChargeCount = 3;
                    }
                    GetComponent<Animator>().SetTrigger("attack");
                    GetComponent<PhotonView>().RPC("gunnerEC", PhotonTargets.AllViaServer);
                }
            }  
        }

        //Mage
        //Fireball
        if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {
            if (cooldownFireball <= 0)
            {
                cooldownFireball += rofFireball;
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("mageFireball", PhotonTargets.AllViaServer);
            }
        }
        
    }

    public void Attack()
    {
        if (canAttackPrimary())
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

    [PunRPC]
    public void gunnerEC()
    {
        var laserShotInstance = Instantiate(secondary1Prefab, transform.position, transform.rotation) as Rigidbody2D;
    }

    [PunRPC]
    public void mageFireball()
    {
        Transform g = transform.Find("FireballSpawn");
        var laserShotInstance = Instantiate(secondary1Prefab, g.position, transform.rotation) as Rigidbody2D;
        
    }

    public bool canAttackPrimary()
    {
        if (cooldown <= 0f)
        return true;
        else { return false; }
    }
}
