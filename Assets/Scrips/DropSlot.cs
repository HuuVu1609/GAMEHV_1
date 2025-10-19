using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // Kiểm tra xem có item được kéo tới không
        DraggableItem draggable = eventData.pointerDrag.GetComponent<DraggableItem>();
        if (draggable != null)
        {
            // Đặt item vào slot mới
            draggable.transform.SetParent(transform);
            draggable.transform.position = transform.position;
        }
    }
}
