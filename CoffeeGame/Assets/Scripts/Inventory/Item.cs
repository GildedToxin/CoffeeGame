using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    public void Interact(PlayerInventory inventory)
    {
        Debug.Log("Player picked up" + gameObject.name);

        var isItemAdded = inventory.TryAddItem(itemData);
        
        if(isItemAdded)
            Destroy(gameObject);
    }
}
