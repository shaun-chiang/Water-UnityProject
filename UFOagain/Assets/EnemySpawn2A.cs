using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn2A : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject basic;
    public GameObject fatso;
    public GameObject runner;

    public float spawnCooldown = 1f;
    public int maxEnemyNo = 20;
    public int enemyCap = 10;
    private int basicNo;
    private int fatsoNo;
    private int runnerNo;
    private List<int> validEnemyChoices = new List<int>();

    private int currEnemyNo;

    void Start()
    {
        validEnemyChoices.Add(0);
        validEnemyChoices.Add(1);
        validEnemyChoices.Add(2);
        basicNo = (int)(maxEnemyNo * 0.4);
        fatsoNo = (int)(maxEnemyNo * 0.2);
        runnerNo = (int)(maxEnemyNo * 0.4);

    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currEnemyNo = enemies.Length;

        if ((currEnemyNo < enemyCap) && (PhotonNetwork.connected))
        {
            if (spawnCooldown > 0)
            {
                spawnCooldown -= Time.deltaTime;
            }

            else if (spawnCooldown <= 0)
            {
                for (int i = 0; i < validEnemyChoices.Count; i++)
                {
                    Debug.Log("Spawn No: " + validEnemyChoices[i]);
                }
                Debug.Log(validEnemyChoices.ToString());
                string enemy;
                int index = Random.Range(0, validEnemyChoices.Count);
                if (index == 0)
                {
                    enemy = basic.name;
                    basicNo -= 1;
                    if (basicNo == 0)
                    {
                        validEnemyChoices.RemoveAt(0);
                    }
                }

                else if (index == 1)
                {
                    enemy = fatso.name;
                    fatsoNo -= 1;
                    if (fatsoNo == 0)
                    {
                        validEnemyChoices.RemoveAt(1);
                    }
                }

                else
                {
                    enemy = runner.name;
                    runnerNo -= 1;
                    if (runnerNo == 0)
                    {
                        validEnemyChoices.RemoveAt(2);
                    }
                }

                spawn(enemy);
            }
        }


    }

    void spawn(string enemyname)
    {
        spawnCooldown = 1f;
        int index = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate(enemyname, spawnPoints[index].position, spawnPoints[index].rotation, 0);
    }
}
