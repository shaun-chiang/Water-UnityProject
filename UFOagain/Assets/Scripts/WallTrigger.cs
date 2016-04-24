using UnityEngine;
using System.Collections;

public class WallTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ExplosiveCharge shot = otherCollider.gameObject.GetComponent<ExplosiveCharge>();
        if (shot != null)
        {
            shot.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

    } 
}
