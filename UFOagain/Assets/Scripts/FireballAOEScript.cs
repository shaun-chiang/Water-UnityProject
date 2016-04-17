using UnityEngine;
using System.Collections;

public class FireballAOEScript : MonoBehaviour {
    public float aoeRange = 1.22f;
    public int aoeDamage = 10;
    private Collider2D[] targets;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AOE()
    {
        targets = Physics2D.OverlapCircleAll(transform.position, aoeRange);

        float step = aoeRange / (float)3.0;
        for (int i = 0; i < targets.Length; i++)
        {
            EnemyHealth eh = targets[i].gameObject.GetComponent<EnemyHealth>();

            //closest
            if (Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < step)
            {
                if (eh != null)
                {
                    eh.Damage(aoeDamage, new Vector2(0,0));
                }
            }
            //second closest
            else if (step < Vector2.Distance(targets[i].gameObject.transform.position, transform.position) && Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < 2*step)
            {
                if (eh != null)
                {
                    eh.Damage(aoeDamage/2, new Vector2(0, 0));
                }
            }
            //third closest
            else if (2*step < Vector2.Distance(targets[i].gameObject.transform.position, transform.position) && Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < 3 * step)
            {
                if (eh != null)
                {
                    eh.Damage(aoeDamage/3, new Vector2(0, 0));
                }
            }
        }
    }
}
