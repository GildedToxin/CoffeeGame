[System.Serializable]
public class InventorySlot
{
    public ItemData item;
    public int count;

    public bool IsEmpty => item == null || count <= 0;

    public bool CanStack(ItemData other)
    {
        return item == other && count < item.maxStack;
    }
}