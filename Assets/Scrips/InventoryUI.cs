using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent; 
    private InventorySlot[] slots;

    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
    }

    public void UpdateUI(List<Item> items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].SetItem(items[i]);
            else
                slots[i].ClearSlot();
        }
    }
}

