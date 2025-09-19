using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot2 : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;

    private void Awake()
    {
        Deselect();
    }
    public void Select()
    {
        image.color = selectedColor;
    }
    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
        Debug.Log("OnDrop");
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
        if (item != null)
        {
            item.parentAfterDrag = transform;
        }
        }
       
    }
}
