using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public ItemType type;
    public int maxStack = 64;
}
public enum ItemType
{
    Ingredient,
    Tool,
    Consumable
}
