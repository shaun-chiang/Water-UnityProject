using UnityEngine;
using System.Collections;

public class NoRotate : MonoBehaviour {

    private Quaternion relativeRotation;
    private Vector2 relativePosition;
    public float heightAboveHead = 0.7f;

	// Use this for initialization
	void Start () {
        relativeRotation = transform.parent.localRotation;
        transform.position = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + 1);
	}
	
	// Update is called once per frame
	void Update () {
        if (true)
        {
            transform.rotation = relativeRotation;
            transform.position = new Vector2(transform.parent.localPosition.x, transform.parent.localPosition.y + heightAboveHead);
        }
	}
}
