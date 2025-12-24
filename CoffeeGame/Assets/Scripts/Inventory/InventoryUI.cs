using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory inventory;
    public InventorySlotUI slotPrefab;
    public Transform slotParent;

    public int rowLength = 10;

    public InventorySlotUI hoveredSlot;
    InventorySlotUI[] uiSlots;

    void Start()
    {
        uiSlots = new InventorySlotUI[inventory.size];

        for (int i = 0; i < inventory.size; i++)
        {
            uiSlots[i] = Instantiate(slotPrefab, slotParent);
            uiSlots[i].Bind(inventory.slots[i]);
            uiSlots[i].inventory = this; 
        }

        inventory.OnInventoryChanged += Refresh;
        Refresh();

        if (GameManager.Instance.inputMode.CurrentDevice == InputModeType.Controller)
        {
            SetHoveredItem(uiSlots[0]);
        }
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
    public void SetHoveredItem(InventorySlotUI slot)
    {
        if(slot == hoveredSlot)
            return;

        hoveredSlot?.selectedBackground.SetActive(false);
        hoveredSlot = slot;
        hoveredSlot?.selectedBackground.SetActive(true);
    }
    public void NavigateInventory(InputAction.CallbackContext ctx)
    {
        // This nav code is intended to be functional, not necessarily scalable
        // This should be reworked once more features are added to the inventory system

        var currentIndex = System.Array.IndexOf(uiSlots, hoveredSlot);




        if(ctx.ReadValue<Vector2>().x != 0)
        {
            var row = (int)currentIndex / 10;

            if(currentIndex == 0 && ctx.ReadValue<Vector2>().x < 0)
            {
                currentIndex = 9 + (row * rowLength);
            }
            else if(currentIndex == 9 + (row * rowLength) && ctx.ReadValue<Vector2>().x > 0)
            {
                currentIndex = 0 + (row * rowLength);
            }
            else

                currentIndex = currentIndex + (int)ctx.ReadValue<Vector2>().x;

         //   SetHoveredItem(uiSlots[Mathf.Clamp((System.Array.IndexOf(uiSlots, hoveredSlot) + (int)ctx.ReadValue<Vector2>().x), 0, uiSlots.Length - 1)]);
        }
        if (ctx.ReadValue<Vector2>().y != 0)
        {
            var tempIndex = currentIndex + (int)(-ctx.ReadValue<Vector2>().y * rowLength);

            if(tempIndex < 0)
                currentIndex += (int)(-ctx.ReadValue<Vector2>().y * -2 * rowLength);

            else if (tempIndex > 30)
                currentIndex += (int)(-ctx.ReadValue<Vector2>().y * 2 * rowLength);

            else
                currentIndex = tempIndex;
        }
        
        if(currentIndex != -1)
            SetHoveredItem(uiSlots[currentIndex]);


    }
    private void OnEnable()
    {
        if (GameManager.Instance.inputMode.CurrentDevice == InputModeType.Controller)
        {
            if (uiSlots[0]!= null)
                SetHoveredItem(uiSlots[0]);
        }
    }
    private void OnDisable()
    {
        SetHoveredItem(null);
    }
}
