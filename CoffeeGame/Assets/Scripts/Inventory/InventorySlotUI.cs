using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text countText;

    public InventorySlot slot;

    public void Bind(InventorySlot newSlot)
    {
        slot = newSlot;
        Refresh();
    }

    public void Refresh()
    {
        if (slot == null || slot.IsEmpty)
        {
            icon.enabled = false;
            countText.text = "";
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.item.icon;
            countText.text = slot.count > 1 ? slot.count.ToString() : "";
        }
    }
}
