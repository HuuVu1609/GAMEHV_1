using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    PickupItem pickup = other.GetComponent<PickupItem>();
    if (pickup != null)
    {
        inventory.AddItem(pickup.item);   // Lưu vào inventory
        Destroy(other.gameObject);        // Xóa item ngoài map
        Debug.Log("Picked up: " + pickup.item.itemName);
            if (inventory == null) // NEW: Debug check
            {
                Debug.LogError("⚠️ Inventory chưa được gán trong PlayerTest!");
                return;
            }
        }
}

}

