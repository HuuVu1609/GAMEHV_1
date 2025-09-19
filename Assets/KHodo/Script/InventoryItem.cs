using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item2 item;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public int count = 1;

    public void InitialiseItem(Item2 newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        RefreshContText();  
    }
    public void RefreshContText()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;    
        countText.gameObject.SetActive(textActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
