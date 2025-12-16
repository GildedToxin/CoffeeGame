using NaughtyAttributes;
using System;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    int money = 0;
    private int maxMoney = 9999;
    public event Action<int> OnMoneyChanged;

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
