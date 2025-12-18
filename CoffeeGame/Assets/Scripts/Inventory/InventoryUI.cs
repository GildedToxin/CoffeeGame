using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public InventorySlotUI slotPrefab;
    public Transform slotParent;

    InventorySlotUI[] uiSlots;

    void Start()
    {
        uiSlots = new InventorySlotUI[inventory.size];

        for (int i = 0; i < inventory.size; i++)
        {
            uiSlots[i] = Instantiate(slotPrefab, slotParent);
            uiSlots[i].Bind(inventory.slots[i]);
        }

        inventory.OnInventoryChanged += Refresh;
        Refresh();
    }

    void Refresh()
    {
        foreach (var slot in uiSlots)
            slot.Refresh();
    }
    public void SetPlayer(PlayerInventory inventory)
    {
        this.inventory = inventory;
    }
}
