using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int MaxItemCount = 4;
    public InventorySlot2[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number <= inventorySlots.Length)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }
    void ChangeSelectedSlot(int newValue)
    {
       if(selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
       inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item2 item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot2 slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemSlot != null && 
                itemSlot.item == item &&
                itemSlot.count < MaxItemCount &&
                itemSlot.item.isStackable == true)  
            {
                itemSlot.count++;
                itemSlot.RefreshContText();
                return true;
            }
        }
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot2 slot = inventorySlots[i];
            InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemSlot == null)
            {
                SqawnItem(item, slot);
                return true;
            }
        }
        return false;
    }
    
    public void SqawnItem(Item2 item, InventorySlot2 slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public Item2 GetSelectedItem(bool use)
    {
        InventorySlot2 slot = inventorySlots[selectedSlot];
        InventoryItem itemSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemSlot != null)
        {
            Item2 item = itemSlot.item;
            if (use == true)
            {
                itemSlot.count--;
                if(itemSlot.count <= 0)
                {
                    Destroy(itemSlot.gameObject);
                }
                else
                {
                    itemSlot.RefreshContText();
                }
            }
            return itemSlot.item;
        }
        return null;    
    }
}
