using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WavesManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySet
    {
        public string name;
        public float delayBeforeStart;
        public GameObject enemyType;
        public int enemyCount;
        public float spawnRate;
    }

    [System.Serializable]
    public class Waves
    {
        public string name;
        public EnemySet[] numberOfEnemySets;
        
    }

    //arrays
    public GameObject[] spawnPoints;
    public Waves[] numberOfWaves;

    //spawn state stuff
    public enum SpawnState {SPAWNING, WAITING}
    private SpawnState state = SpawnState.SPAWNING;

    //wave counter
    public int waveCount = 0;
    float waitTime;
    bool isDone = false;
    private void Update()
    {
        {

            if (waveCount != numberOfWaves.Length)
            {
                if (state == SpawnState.SPAWNING)
                {
                    StartCoroutine(spawnEnemies());
                }
                else if (state == SpawnState.WAITING)
                {

                    if (isDone == true && GameObject.FindGameObjectsWithTag("Enemy").Length <= 3)
                    {
                        Debug.Log("Spawning: " + waveCount);
                        waveCount += 1;
                        isDone = false;
                        state = SpawnState.SPAWNING;
                    }
                }
            }
            else if(GameObject.FindGameObjectsWithTag("Enemy").Length <=0)
            {
                SceneManager.LoadScene(2);
            }
        }
        IEnumerator spawnEnemies()
        {
            state = SpawnState.WAITING;

            foreach (var enemySet in numberOfWaves[waveCount].numberOfEnemySets)
            {
                yield return new WaitForSeconds(enemySet.delayBeforeStart);
                for (int i = 0; i < enemySet.enemyCount; i++)
                {
                    int chosenSpawnPoint = Random.Range(0, spawnPoints.Length - 1);
                    Vector3 spawnLocation = new Vector3(spawnPoints[chosenSpawnPoint].transform.position.x, spawnPoints[chosenSpawnPoint].transform.position.y, 1.9f);
                    Instantiate(enemySet.enemyType, spawnLocation, Quaternion.identity);
                    yield return new WaitForSeconds(enemySet.spawnRate);
                }
            }
            StopCoroutine(spawnEnemies());
            isDone = true;
        }
    }
}
