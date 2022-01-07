using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTree : Interactable
{
    [Header("Tree Properties")]
    [SerializeField]
    private float maxTreeHealth = 40;
    private float currentTreeHealth;
    [SerializeField]
    private GameObject treeTrunkPrefab;

    [Header("Spawnable Items")]
    [SerializeField]
    private List<ItemSpawnRate> spawnableItems;


    protected override void Start()
    {
        currentTreeHealth = maxTreeHealth;
        base.Start();
    }


    public override void OnPlayerInteract()
    {
        currentTreeHealth -= 10.0f;

        if (currentTreeHealth <= 0)
        {
            SpawnItemsOnDestruction();
            Instantiate(treeTrunkPrefab, transform.position, Quaternion.identity, this.transform.parent);
            Destroy(gameObject);
        }
            
        base.OnPlayerInteract();
    }

    protected override void SpawnItemsOnDestruction()
    {
        base.SpawnItemsOnDestruction();

        for (int i = 0; i < spawnableItems.Count; i++)
        {
            if(Random.Range(0,100) < spawnableItems[i].itemspawnChance)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-3, 3),
                                                    10,
                                                    transform.position.z + Random.Range(-3, 3));

                Instantiate(spawnableItems[i].itemData.itemPrefab,spawnPosition,Quaternion.identity, this.transform.parent);
                Debug.Log("Spawning Log");
            }
        }
    }
}
