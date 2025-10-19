using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int slotCount = 20; // Số ô tối đa
    public List<Item> items = new List<Item>();

    public bool AddItem(Item newItem)
    {
        if (items.Count >= slotCount)
        {
            Debug.Log("Inventory đầy!");
            return false;
        }

        items.Add(newItem);
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
