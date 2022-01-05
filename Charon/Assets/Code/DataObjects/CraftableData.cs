using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craftable", menuName = "Data Objects/Craftable", order = 2)]
public class CraftableData : ScriptableObject
{
    public List<ToolData> requiredTools;
    public List<InventoryItem> requiredInventoryItems;
}
