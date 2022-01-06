using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject treePrefab;

    [Header("CampFire Boundaries")]
    [SerializeField]
    private int boundaryX;
    [SerializeField]
    private int boundaryY;

    [Header("Generation Properties")]
    [SerializeField]
    private int minNumberOfTree;
    [SerializeField]
    private int maxNumberOfTrees;

    private void Start()
    {
        GenerateCamp();
    }

    private void GenerateCamp()
    {
        int numOfTrees = Random.Range(minNumberOfTree, maxNumberOfTrees);

        List<Vector3> treeSpawnPositions = new List<Vector3>();

        for (int i = 0; i < numOfTrees; i++)
        {
            bool isValidSpawnPoint = true;
            Vector3 treeSpawnPosition = Vector3.one;

            do
            {
                treeSpawnPosition = transform.position + new Vector3((Random.value - 0.5f) * boundaryX, 0, (Random.value - 0.5f) * boundaryY);

                if(treeSpawnPositions.Count > 0)
                {
                    isValidSpawnPoint = IsValidPosition(treeSpawnPosition, treeSpawnPositions);
                }
            }
            while (!isValidSpawnPoint);

            treeSpawnPositions.Add(treeSpawnPosition);
            GameObject newTree = Instantiate(treePrefab);
            newTree.transform.transform.position = treeSpawnPosition;
            newTree.transform.parent = this.transform;
        }
    }

    private bool IsValidPosition(Vector3 treePosition, List<Vector3> treeSpawnPositions)
    {
        for (int i = 0; i < treeSpawnPositions.Count; i++)
        {
            if (Vector3.Distance(treePosition, treeSpawnPositions[i]) < 7)
            {
                return false;
            }
        }

        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(boundaryX, 1, boundaryY));
    }
}
