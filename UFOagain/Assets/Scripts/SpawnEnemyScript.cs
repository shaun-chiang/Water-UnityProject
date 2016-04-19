using UnityEngine;
using System.Collections;

public class SpawnEnemyScript : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemy2;
    //public GameObject[] enemies;
    public Transform[] spawnPoints;
    public float spawnCooldown = 5f;
    public int maxEnemyNo = 20;

    private int currEnemyNo;

	void Start () {

	}

	
	void Update () {
        if ((currEnemyNo < maxEnemyNo) && (PhotonNetwork.connected))
        {
            if (spawnCooldown > 0)
            {
                spawnCooldown -= Time.deltaTime;
            }

            else if (spawnCooldown <= 0)
            {
                spawn(enemy.name);
            }
        }

        
	}

    void spawn(string enemyname)
    {
        currEnemyNo += 1;
        spawnCooldown = 3f;
        int index = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate(enemyname, spawnPoints[index].position, spawnPoints[index].rotation, 0);
    }
}
