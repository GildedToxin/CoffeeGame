using UnityEngine;

public class TestInteractableScript : MonoBehaviour, IInteractable
{
    public void Interact(PlayerInventory inventory)
    {
        Debug.Log("Interacted with " + gameObject.name);
        Destroy(gameObject);
    }
}
