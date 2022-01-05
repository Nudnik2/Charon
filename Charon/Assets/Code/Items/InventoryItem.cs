[System.Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int itemAmount;

    public InventoryItem(ItemData _itemData, int _itemAmount)
    {
        itemData = _itemData;
        itemAmount = _itemAmount;
    }
}
