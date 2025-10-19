using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // hình ảnh item trong slot
    private Item item;

    public void SetItem(Item newItem) // gán item mới vào slot
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
    }

    public void ClearSlot() // xoá item khỏi slot
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public bool IsEmpty() // kiểm tra slot có rỗng không
    {
        return item == null;
    }
}
