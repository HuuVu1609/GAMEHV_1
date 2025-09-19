using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item2[] itemToPickUp;

    public void PickUpItem(int id)
    {
        bool result = inventoryManager.AddItem(itemToPickUp[id]);
        if (result == true)
        {
           Debug.Log("Picked up: " + itemToPickUp[id].name); 
        }
        else{
            Debug.Log("Inventory Full");
        }
    }
    public void GetSelectedItem()
    {
        Item2 selectedItem = inventoryManager.GetSelectedItem(false);
        if(selectedItem != null)
        {
            Debug.Log("Selected Item: " + selectedItem.name);

        }
        else
        {
            Debug.Log("No Item Selected");
        }

    }
    public void UseSelectedItem()
    {
        Item2 selectedItem = inventoryManager.GetSelectedItem(true);
        if(selectedItem != null)
        {
            Debug.Log("Used Item: " + selectedItem.name);
        }
        else
        {
            Debug.Log("No Item Selected");
        }
    }
}
