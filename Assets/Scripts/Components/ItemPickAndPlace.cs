using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickAndPlace : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Canvas canvas;

    private RectTransform rectTransform;
    private Inventory inventory;
    public bool draggable = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        inventory = GetComponentInChildren<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("end drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnDrop(PointerEventData eventData)
    {
        print("drop");
    }
}
