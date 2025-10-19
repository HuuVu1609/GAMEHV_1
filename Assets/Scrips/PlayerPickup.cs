using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Inventory inventory;
    public ItemDatabase itemDatabase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickupItem pickup = collision.GetComponent<PickupItem>();
        if (pickup != null)
        {
            bool added = inventory.AddItem(pickup.item);
            if (added)
            {
                Destroy(collision.gameObject); // xoá item trên ground
            }
        }
    }
}