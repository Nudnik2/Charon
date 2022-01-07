using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelerManager : MonoBehaviour
{
    [Header("Traveler Prefab")]
    [SerializeField]
    private GameObject travelerPrefab;

    [Header("Positions")]
    [SerializeField]
    private Transform[] travelerSpawnPositions;
    [SerializeField]
    private Transform[] travelerEndPositions;

    private void Start()
    {
        StartCoroutine("SpawnTravelers");
    }

    IEnumerator SpawnTravelers()
    {
        while(true)
        {
            float randomTime = Random.Range(5, 10);
            yield return new WaitForSeconds(randomTime);

            Transform spawnTransform = travelerSpawnPositions[Random.Range(0, travelerSpawnPositions.Length)];
            Vector3 spawnPosition = new Vector3(spawnTransform.position.x, 1, spawnTransform.position.z);
            GameObject traveler = Instantiate(travelerPrefab, spawnPosition, Quaternion.identity);

            Unit pathfinding = traveler.GetComponent<Unit>();
            pathfinding.SetPathTarget(travelerEndPositions[Random.Range(0, travelerEndPositions.Length)]);
        }
    }
}
