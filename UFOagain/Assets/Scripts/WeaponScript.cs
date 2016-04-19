using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class WeaponScript : Photon.PunBehaviour
{
    //General
    public Rigidbody2D laserShotPrefab;
    //public Rigidbody2D[] secondaries;
    public Rigidbody2D secondary1Prefab;
    public Rigidbody2D secondary2Prefab;
    public Rigidbody2D secondary3Prefab;
    public float rof = 1f;

    //Gunner
    //Headshot
    public static int HeadShotCount = 1;
    int temphscount = HeadShotCount;
    public float rofHS = 7f;
    private float coolDownHS;
    public float rofperHS = 1f;
    private float cooldownperHS = 0f;



    //Explosive Charge 
    public static int explosiveChargeCount = 2;
    int tempECcount = explosiveChargeCount;
    public float rofEC = 8f;
    private float cooldownEC;
    public float rofperCharge = 1f;
    private float cooldownPerCharge = 0f;

    //FinalGambit
    public int FGcount = 1;
    public float rofFG = 5f;
    private float cooldownFG;
    public float rofperFG = 1f;
    private float coolDownperFG = 1f;




    //Mage
    //Fireball
    public float rofFireball = 4f;
    private float cooldownFireball = 0f;

    //BoltStrike
    public float rofBS = 9f;
    private float cooldownBS = 0f;

    //Blizzard
    public int BZcount = 1;
    public float rofBZ = 3f;
    private float cooldownBZ;
    public float rofperBZ = 1f;
    private float coolDownperBZ = 1f;



    //Archer
    //Piercing Shot
    public static int PSCount = 2;
    int tempPscount = PSCount;
    public float rofPS = 3f;
    private float cooldownPS = 0f;
    public float rofperPS = 1f;
    private float coolDownperPS = 2f;


    //ExplosiveShot
    public static int explosiveShotCount = 1;
    int tempescount = explosiveShotCount;
    public float rofES = 5f;
    private float cooldownES;
    public float rofperES = 1f;
    private float cooldownPerES = 0f;

    //ArrowStorm
    public float rofAS = 10f;
    public float coolDownAS = 0f;

    //Paladin
    //ShieldCharge
    public float rofSC = 3f;
    private float cooldownSC = 0f;

    //Heaven Hammer
    public float rofHH = 3f;
    private float cooldownHH = 0f;

    //Divine Judgment
    public float rofDJ = 8f;
    private float cooldownDJ = 0f;



    private float cooldown;


    // Use this for initialization
    void Start()
    {
        name = gameObject.name;
        cooldown = 0f;

        //temphscount = HeadShotCount;

    }

    // Update is called once per frame
    void Update()
    {
        //Basic Shot
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Gunner
        //HeadShot Cooldown
        if (coolDownHS > 0)
        {
            coolDownHS -= Time.deltaTime;
        }

        if (cooldownperHS > 0)
        {
            cooldownperHS -= Time.deltaTime;
        }


        //Explosive Charge Cooldown - Place 3 charges then cooldown starts
        if (cooldownEC > 0)
        {
            cooldownEC -= Time.deltaTime;
        }

        if (cooldownPerCharge > 0)
        {
            cooldownPerCharge -= Time.deltaTime;
        }

        //Final Gambit cooldown

        if (cooldownFG > 0)
        {
            cooldownFG -= Time.deltaTime;
        }

        if (coolDownperFG > 0)
        {
            coolDownperFG -= Time.deltaTime;
        }

        //Mage 
        //Fireball
        if (cooldownFireball > 0)
        {
            cooldownFireball -= Time.deltaTime;
        }

        //BoltStrike

        if (cooldownBS > 0)
        {
            cooldownBS -= Time.deltaTime;
        }

        //Blizzard
        if (cooldownBZ > 0)
        {
            cooldownBZ -= Time.deltaTime;
        }

        if (coolDownperBZ > 0)
        {
            coolDownperBZ -= Time.deltaTime;
        }


        //Archer
        //PiercingShot

        if (cooldownPS > 0)
        {
            cooldownPS -= Time.deltaTime;
        }

        if (coolDownperPS > 0)
        {
            coolDownperPS -= Time.deltaTime;
        }

        //ExplosiveShot

        if (cooldownES > 0)
        {
            cooldownES -= Time.deltaTime;
        }

        if (cooldownPerES > 0)
        {
            cooldownPerES -= Time.deltaTime;
        }

        //Arrow Storm

        if (coolDownAS > 0)
        {
            coolDownAS -= Time.deltaTime;
        }

        //Paladin
        //ShieldCharge

        if (cooldownSC > 0)
        {
            cooldownSC -= Time.deltaTime;
        }

        //HeavenHammer
        if (cooldownHH > 0)
        {
            cooldownHH -= Time.deltaTime;
        }

        //Divine Judgement

        if (cooldownDJ > 0)
        {
            cooldownDJ -= Time.deltaTime;
        }




    }

    public void Secondary1()
    {
        Debug.Log("Secondary: " + PlayerPrefs.GetString("Class"));
        //Gunner 
        //HeadShot
        if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {
           gunnerExplosiveCharge();
           // gunnerHeadShot();
            //gunnerFinalGambit();
        }


        //Mage
        //Fireball
        if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {
            mageFireball();
        }
        //Archer
        //PiercingShot
        if (PlayerPrefs.GetString("Class").Equals("Archer"))
        {

            //archerPiercingShot();
            //archerExplosiveShot();
            archerArrowStorm();
        }

        if (PlayerPrefs.GetString("Class").Equals("Paladin"))
        {

            paladinDivineJudgment();
        }

    }

    public void Secondary2()
    {
        //Gunner 
        //Explosive Charge
        if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {
            gunnerFinalGambit();
        }

        //Mage
        //BoltStrike
        if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {

            mageBoltStrike();
        }



        //Archer
        //ExplosiveShot
        if (PlayerPrefs.GetString("Class").Equals("Archer"))
        {
            archerExplosiveShot();
        }


        if (PlayerPrefs.GetString("Class").Equals("Paladin"))
        {

            paladinHeavenHammer();
        }



    }

    public void Secondary3()
    {
        //Gunner 
        //Final Gambit
        if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {
            gunnerHeadShot();

        }

        //Mage
        //Blizzard
        if (PlayerPrefs.GetString("Class").Equals("Mage"))
        {
            mageBlizzard();
        }



        //Archer
        //ExplosiveShot
        if (PlayerPrefs.GetString("Class").Equals("Archer"))
        {
            archerPiercingShot();
        }

        //Paladin
        //DivineJudgment
        if (PlayerPrefs.GetString("Class").Equals("Paladin"))
        {
            paladinShieldCharge();
        }





    }

    public void Attack()
    {
        if (canAttackPrimary())
        {
            GetComponent<Animator>().SetTrigger("attack");
            cooldown = rof;
            GetComponent<PhotonView>().RPC("shotActive", PhotonTargets.AllViaServer);
        }
    }

    //Basic Shot
    [PunRPC]
    public void shotActive()
    {
        if (PlayerPrefs.GetString("Class").Equals("Gunner"))
        {

            var laserShotInstance = Instantiate(laserShotPrefab, transform.position, transform.rotation) as Rigidbody2D;
            laserShotInstance.gameObject.GetComponent<Shot2>().PrefabID = gameObject.GetInstanceID();
        }
        else {
            var laserShotInstance = Instantiate(laserShotPrefab, transform.position, transform.rotation) as Rigidbody2D;
            laserShotInstance.gameObject.GetComponent<Shot>().PrefabID = gameObject.GetInstanceID();
        }
    }

    //Gunner Secondary Skills
    public void gunnerHeadShot()
    {
        //HeadShotCount;
        //temphscount = HeadShotCount;
        if (cooldownperHS <= 0)
        {
            if (temphscount > 0 && coolDownHS <= 0f)
            {
                cooldownperHS += rofperHS;
                temphscount -= 1;
                if (temphscount == 0)
                {
                    coolDownHS += rofHS;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary3").GetComponent<ButtonCooldown>().setCd(coolDownHS);
                    temphscount = HeadShotCount;
                }

                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("gunnerHeadShotRPC", PhotonTargets.AllViaServer);
            }

        }
    }
    [PunRPC]
    public void gunnerHeadShotRPC()
    {
        var laserShotInstance = Instantiate(secondary3Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<Shot>().PrefabID = gameObject.GetInstanceID();
    }




    //Explosive Charge Skill
    public void gunnerExplosiveCharge()
    {
        if (cooldownPerCharge <= 0)
        {
            if (tempECcount > 0 && cooldownEC <= 0f)
            {
                cooldownPerCharge += rofperCharge;
                tempECcount -= 1;
                if (tempECcount == 0)
                {
                    cooldownEC += rofEC;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary").GetComponent<ButtonCooldown>().setCd(cooldownEC);
                    tempECcount = explosiveChargeCount;
                }
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("gunnerExplosiveChargeRPC", PhotonTargets.AllViaServer);
            }
        }
    }

    [PunRPC]
    public void gunnerExplosiveChargeRPC()
    {
        var laserShotInstance = Instantiate(secondary1Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<ExplosiveCharge>().PrefabID = gameObject.GetInstanceID();
    }




    //Final Gambit Skill
    public void gunnerFinalGambit()
    {
        if (coolDownperFG <= 0)
        {
            if (FGcount > 0 && cooldownFG <= 0f)
            {
                coolDownperFG += rofperFG;
                FGcount -= 1;
                if (FGcount == 0)
                {
                    cooldownFG += rofFG;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary2").GetComponent<ButtonCooldown>().setCd(cooldownFG);
                    FGcount = 3;
                }
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("gunnerFinalGambitRPC", PhotonTargets.AllViaServer);
            }
        }
    }
    [PunRPC]
    public void gunnerFinalGambitRPC()
    {
        var laserShotInstance = Instantiate(secondary2Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<FinalGambit2>().PrefabID = gameObject.GetInstanceID();

    }

    //Mage Secondary Skills
    //Fireball Skill
    public void mageFireball()
    {
        if (cooldownFireball <= 0)
        {
            cooldownFireball += rofFireball;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary").GetComponent<ButtonCooldown>().setCd(cooldownFireball);
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("mageFireballRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void mageFireballRPC()
    {
        Transform g = transform.Find("FireballSpawn");
        var laserShotInstance = Instantiate(secondary1Prefab, g.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<FireballAOEScript>().PrefabID = gameObject.GetInstanceID();
        laserShotInstance.gameObject.GetComponent<Shot>().PrefabID = gameObject.GetInstanceID();
    }

    //BoltStrike

    public void mageBoltStrike()
    {
        if (cooldownBS <= 0)
        {
            cooldownBS += rofBS;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary2").GetComponent<ButtonCooldown>().setCd(cooldownBS);
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("mageBoltStrikeRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void mageBoltStrikeRPC()
    {

        var laserShotInstance = Instantiate(secondary2Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<BoltStrike>().PrefabID = gameObject.GetInstanceID();
    }
    //Blizzard

    public void mageBlizzard()
    {
        if (coolDownperBZ <= 0)
        {
            if (BZcount > 0 && cooldownFG <= 0f)
            {
                coolDownperBZ += rofperBZ;
                BZcount -= 1;
                if (BZcount == 0)
                {
                    cooldownBZ += rofBZ;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary3").GetComponent<ButtonCooldown>().setCd(cooldownBZ);
                    BZcount = 3;
                }
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("mageBlizzardRPC", PhotonTargets.AllViaServer);
            }
        }
    }
    [PunRPC]
    public void mageBlizzardRPC()
    {
        var laserShotInstance = Instantiate(secondary3Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<Blizzard>().PrefabID = gameObject.GetInstanceID();

    }




    //Archer Secondary Skills
    //PiercingShot

    public void archerPiercingShot()
    {

        if (coolDownperPS <= 0)
        {
            if (tempPscount > 0 && cooldownPS <= 0f)
            {
                coolDownperPS += rofperHS;
                tempPscount -= 1;
                if (tempPscount == 0)
                {
                    cooldownPS += rofPS;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary3").GetComponent<ButtonCooldown>().setCd(cooldownPS);
                    tempPscount = PSCount;
                }
            }

            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("archerPiercingShotRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void archerPiercingShotRPC()
    {
        var laserShotInstance = Instantiate(secondary3Prefab, transform.position, transform.rotation) as Rigidbody2D;
        
            Debug.LogError(gameObject.GetInstanceID() + "       other id");
            laserShotInstance.gameObject.GetComponent<ArcherPiercing>().PrefabID = gameObject.GetInstanceID();
        
    }


    //ExplosiveShot
    public void archerExplosiveShot()
    {
        if (cooldownPerES <= 0)
        {
            if (tempescount > 0 && cooldownES <= 0f)
            {
                cooldownPerES += rofperES;
                tempescount -= 1;
                if (tempescount == 0)
                {
                    cooldownES += rofES;
                    GameObject controls = GameObject.Find("MobileSingleStickControl");
                    controls.transform.Find("ShootSecondary2").GetComponent<ButtonCooldown>().setCd(cooldownES);
                    tempescount = explosiveShotCount;
                }
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<PhotonView>().RPC("archerExplosiveShotRPC", PhotonTargets.AllViaServer);
            }

        }
    }
    [PunRPC]
    public void archerExplosiveShotRPC()
    {
        var laserShotInstance = Instantiate(secondary2Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<ExplosiveShot>().PrefabID = gameObject.GetInstanceID();
    }

    //ArrowStorm
    public void archerArrowStorm()
    {
        if (coolDownAS <= 0)
        {
            coolDownAS += rofAS;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary").GetComponent<ButtonCooldown>().setCd(coolDownAS);
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("archerArrowStormRPC", PhotonTargets.AllViaServer);
        }

    }


    [PunRPC]
    public void archerArrowStormRPC()
    {

        var laserShotInstance = Instantiate(secondary1Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<ArrowRain>().PrefabID = gameObject.GetInstanceID();
    }




    //Paladin Secondary Skills
    //Shield Charge

    public void paladinShieldCharge()
    {
        if (cooldownSC <= 0)
        {
            cooldownSC += rofSC;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary3").GetComponent<ButtonCooldown>().setCd(cooldownSC);
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("paladinShieldChargeRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void paladinShieldChargeRPC()
    {

        var laserShotInstance = Instantiate(secondary3Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<ShieldCharge>().PrefabID = gameObject.GetInstanceID();
    }


    //Heaven Hammer
    public void paladinHeavenHammer()
    {
        if (cooldownHH <= 0)
        {
            cooldownHH += rofHH;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary2").GetComponent<ButtonCooldown>().setCd(cooldownHH);
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("paladinHeavenHammerRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void paladinHeavenHammerRPC()
    {
        var laserShotInstance = Instantiate(secondary2Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<HeavensHammer>().PrefabID = gameObject.GetInstanceID();
    }

    //Divine Judgement

    public void paladinDivineJudgment()
    {
        if (cooldownDJ <= 0)
        {
            cooldownDJ += rofDJ;
            GameObject controls = GameObject.Find("MobileSingleStickControl");
            controls.transform.Find("ShootSecondary").GetComponent<ButtonCooldown>().setCd(cooldownDJ); 
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<PhotonView>().RPC("paladinDivineJudgmentRPC", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void paladinDivineJudgmentRPC()
    {
        var laserShotInstance = Instantiate(secondary1Prefab, transform.position, transform.rotation) as Rigidbody2D;
        laserShotInstance.gameObject.GetComponent<DivineJudgment>().PrefabID = gameObject.GetInstanceID();
    }

    public bool canAttackPrimary()
    {
        if (cooldown <= 0f)
            return true;
        else { return false; }
    }


}


