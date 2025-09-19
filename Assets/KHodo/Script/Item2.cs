using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Item2", menuName = "Scriptable Objects/Item2")]
public class Item2 : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tileBase;
    public ItemType itemType;
    public ActionType actionType;
    public Vector2Int range =new Vector2Int(5,4);

    [Header("Only UI")]
    public bool isStackable = true;

    [Header("Both")]
    public Sprite icon;
}
public enum ItemType
{
    BuildingBlock,
    Tool
}
public enum ActionType
{
    Dig,
    Mine
}