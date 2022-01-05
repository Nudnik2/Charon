using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField]
    private List<ToolData> inventoryTools = new List<ToolData>();

    [SerializeField]
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();

    public bool PlayerInventoryContainsTool(ToolData tool)
    {
        if (inventoryTools.Contains(tool))
            return true;
        else
            return false;
    }

    public bool PlayerInventoryContainsItem(InventoryItem inventoryItem)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if(inventoryItems[i].itemData == inventoryItem.itemData)
            {
                if(inventoryItems[i].itemAmount >= inventoryItem.itemAmount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return false;
    }
}