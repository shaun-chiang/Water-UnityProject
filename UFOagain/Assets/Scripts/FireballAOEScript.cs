using UnityEngine;
using System.Collections;

public class FireballAOEScript : MonoBehaviour {
	public int PrefabID;
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
            if (eh != null)
            {
                eh.setFirehit(true);
                //closest
                if (Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < step)
                {
                    
                        eh.Damage(aoeDamage, new Vector2(0, 0));
                    
                }
                //second closest
                else if (step < Vector2.Distance(targets[i].gameObject.transform.position, transform.position) && Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < 2 * step)
                {
                    
                        eh.Damage(aoeDamage / 2, new Vector2(0, 0));
                    
                }
                //third closest
                else if (2 * step < Vector2.Distance(targets[i].gameObject.transform.position, transform.position) && Vector2.Distance(targets[i].gameObject.transform.position, transform.position) < 3 * step)
                {
                    
                        eh.Damage(aoeDamage / 3, new Vector2(0, 0));
                    
                }
            }



			if (PrefabID != targets[i].gameObject.GetInstanceID ()) {
				HealthScript hs = targets[i].gameObject.GetComponent<HealthScript> ();
				if (hs != null) {

					hs.AdjustHealth (aoeDamage/2 * -1);
				}


			}
        }
    }
}
