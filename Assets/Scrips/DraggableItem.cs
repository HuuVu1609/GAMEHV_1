using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform khungUI;          // RectTransform của item
    private CanvasGroup nhomCanvas;         // CanvasGroup để điều khiển raycast
    private Vector3 viTriBanDau;            // Lưu lại vị trí ban đầu
    private Transform chaBanDau;            // Lưu lại cha gốc (slot ban đầu)

    void Awake()
    {
        khungUI = GetComponent<RectTransform>();
        nhomCanvas = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData suKien)
    {
        viTriBanDau = khungUI.position;
        chaBanDau = transform.parent;

        nhomCanvas.blocksRaycasts = false; // Cho phép slot khác nhận thả
    }

    public void OnDrag(PointerEventData suKien)
    {
        khungUI.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData suKien)
    {
        nhomCanvas.blocksRaycasts = true;

        // Nếu không thả vào slot nào → quay lại chỗ cũ
        if (transform.parent == chaBanDau)
        {
            khungUI.position = viTriBanDau;
        }
    }
}
