using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public TMP_Text countText;
    public InventorySlot slot;
    public bool isSlotHovered;

    public InventoryUI inventory;
    public GameObject selectedBackground;

    public void Bind(InventorySlot newSlot)
    {
        slot = newSlot;
        Refresh();
    }

    public void Refresh()
    {
        if (slot == null || slot.IsEmpty)
        {
            //icon.enabled = false;
            countText.text = "";
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.item.icon;
            countText.text = slot.count > 1 ? slot.count.ToString() : "";
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isSlotHovered = true;
        inventory.SetHoveredItem(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isSlotHovered = false;
    }
    
}
