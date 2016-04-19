using UnityEngine;
using System.Collections;

public class RunnerAttack : MonoBehaviour {
    Transform target;
	void Start () {
        target = GetComponent<AILerp>().target;
	}
	
	// Update is called once per frame
	void Update () {
	    if (target == null)
        {
            target = GetComponent<AILerp>().target;
        }

        else
        {
            if (Vector2.Distance(transform.position, target.position) < 2)
            {
                Debug.Log("SETTING TRIG");
                GetComponent<Animator>().SetTrigger("attack");
            }
        }
	}
}
