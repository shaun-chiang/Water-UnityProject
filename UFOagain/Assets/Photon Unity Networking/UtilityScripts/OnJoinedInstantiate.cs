using UnityEngine;
using System.Collections;

public class OnJoinedInstantiate : MonoBehaviour
{
    public Transform SpawnPosition;
    public float PositionOffset = 2.0f;
    public GameObject[] PrefabsToInstantiate;   // set in inspector
	GameObject go;
	bool bounds;
    public void OnJoinedRoom()
    {
        if (this.PrefabsToInstantiate != null)
        {
            foreach (GameObject o in this.PrefabsToInstantiate)
            {
				bounds = true;
                Debug.Log("Instantiating: " + o.name);

                Vector3 spawnPos = Vector3.up;
                if (this.SpawnPosition != null)
                {
                    spawnPos = this.SpawnPosition.position;
                }

                Vector3 random = Random.insideUnitSphere;
                random.y = 0;
                random = random.normalized;
                Vector3 itempos = spawnPos + this.PositionOffset * random;
				//BoxCollider2D boundary = gameObject.AddComponent<BoxCollider2D>();


                PhotonNetwork.Instantiate(o.name, itempos, Quaternion.identity, 0);

				/*if (bounds) {
					go = new GameObject ();

					BoxCollider2D collider = go.AddComponent<BoxCollider2D> ();
					collider.transform.position = new Vector3 (-0.06f, -0.41f, 3.5781f);
					collider.offset = new Vector2 (-0.5145278f, -0.5683146f);
					collider.size = new Vector2 (15.94691f,15.95901f);
					bounds = false;


				}
				*/
            }
        }
    }
}
