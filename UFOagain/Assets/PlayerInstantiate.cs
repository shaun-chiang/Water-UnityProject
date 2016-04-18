using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class PlayerInstantiate : MonoBehaviour
{
    public Transform MageSpawn;
    public Transform ArcherSpawn;
    public Transform GunnerSpawn;
    public Transform PaladinSpawn;

    public float PositionOffset = 0f;
    public GameObject[] PrefabsToInstantiate;   // set in inspector


    public void Start()
    {
        if (this.PrefabsToInstantiate != null)
        {
            foreach (GameObject o in this.PrefabsToInstantiate)
            {
                Debug.Log(PlayerPrefs.GetString("Class"));
                if (o.name.Equals(PlayerPrefs.GetString("Class")))
                {
                    Debug.Log("Instantiating: " + o.name);

                    Vector3 spawnPos = Vector3.up;
                    if (o.name.Equals("Mage"))
                    {
                        spawnPos = this.MageSpawn.position;
                    } else if (o.name.Equals("Archer"))
                    {
                        spawnPos = this.ArcherSpawn.position;
                    }
                    else if(o.name.Equals("Gunner"))
                    {
                        spawnPos = this.GunnerSpawn.position;
                    } else if (o.name.Equals("Paladin"))
                    {
                        spawnPos = this.PaladinSpawn.position;
                    }

                        Vector3 random = Random.insideUnitSphere;
                    random.y = 0;
                    random = random.normalized;
                    Vector3 itempos = spawnPos;// + this.PositionOffset * random;

                    PhotonNetwork.Instantiate(o.name, itempos, Quaternion.identity, 0);
                }
            }
        }
    }
}



