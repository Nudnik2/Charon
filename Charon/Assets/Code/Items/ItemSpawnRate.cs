using UnityEngine;

[System.Serializable]
public class ItemSpawnRate
{
    public ItemData itemData;
    [Range(0, 100)]
    public int itemspawnChance;
}
