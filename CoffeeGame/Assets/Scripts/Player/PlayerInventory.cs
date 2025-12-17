using NaughtyAttributes;
using System;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    int money = 0;
    private int maxMoney = 9999;
    public event Action<int> OnMoneyChanged;

    public int size = 36;
    public InventorySlot[] slots;

    public Action OnInventoryChanged;


    void Awake()
    {
        slots = new InventorySlot[size];
        for (int i = 0; i < size; i++)
            slots[i] = new InventorySlot();
    }
    public bool TryAddItem(ItemData item, int amount = 1)
    {
        // Try stacking first
        foreach (var slot in slots)
        {
            if (slot.CanStack(item))
            {
                int space = item.maxStack - slot.count;
                int toAdd = Mathf.Min(space, amount);
                slot.count += toAdd;
                amount -= toAdd;
                if (amount <= 0) // Only returns if all items were added
                {
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
        }

        // Find empty slots
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.item = item;
                slot.count = Mathf.Min(item.maxStack, amount);
                amount -= slot.count;
                if (amount <= 0)
                {
                    OnInventoryChanged?.Invoke();
                    return true; 
                }
            }
        }

        OnInventoryChanged?.Invoke();
        return false; // Inventory full
    }



    [Button]
    public void AddMoney()
    {
        AddMoney(45);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        money = Mathf.Clamp(money, 0, maxMoney);
        OnMoneyChanged?.Invoke(money);
    }

}
