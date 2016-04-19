using UnityEngine;
using System.Collections;

public class FatsoAttackScript2 : MonoBehaviour {
    public int acidRange = 4;
    public float rofAcid = 2f;
    public Rigidbody2D acidPrefab;

    private float cooldownAcid = 0f;
    private Transform target;
    
	// Use this for initialization
	void Start () {
        target = GetComponent<AILerp>().target;
	}
	
	// Update is called once per frame
	void Update () {
        if (target != GetComponent<AILerp>().target)
        {
            target = GetComponent<AILerp>().target;
        }

        if (Vector2.Distance(transform.position, target.position) <= acidRange)
        {
            acidAttack();
        }
        

        if (cooldownAcid > 0)
        {
            cooldownAcid -= Time.deltaTime;
        }
	}

    public void acidAttack()
    {
        if (canAcidAttack())
        {
            GetComponent<Animator>().SetTrigger("attack");
            cooldownAcid += rofAcid;
            GetComponent<PhotonView>().RPC("shotActiveFatso", PhotonTargets.AllViaServer);
        }
    }
    [PunRPC]
    public void shotActiveFatso()
    {
        var acidInstance = Instantiate(acidPrefab, transform.position, transform.rotation) as Rigidbody2D;
        acidInstance.GetComponent<Shot>().setTargetPos(target.position);
        //acidInstance.SendMessage("setTargetPos", target.position);
    }

    public bool canAcidAttack()
    {
        if (cooldownAcid <= 0)
        {
            return true;
        }
        return false;
    }
}
