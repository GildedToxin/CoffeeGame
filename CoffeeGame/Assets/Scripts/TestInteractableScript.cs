using UnityEngine;

public class TestInteractableScript : MonoBehaviour, IInteractable
{
    public ItemData itemData;
    public void Interact(PlayerInventory inventory)
    {
        Debug.Log("Interacted with " + gameObject.name);

        inventory.TryAddItem(itemData);
        Destroy(gameObject);
    }
}
