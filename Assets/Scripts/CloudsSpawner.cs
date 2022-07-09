using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cloudPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnerCloud());   
    }

    IEnumerator SpawnerCloud()
    {
        while(true)
        {
            int randN = Random.Range(0, cloudPrefabs.Length);
            Vector3 randPoint = new Vector3(Random.Range(spawnPoints[0].position.x - 3f, spawnPoints[1].position.x),
                                            Random.Range(spawnPoints[0].position.y, spawnPoints[1].position.y),
                                            0 );
            Instantiate(cloudPrefabs[randN], randPoint, Quaternion.identity, null);
            yield return new WaitForSeconds(3f);
        }

    }
}
