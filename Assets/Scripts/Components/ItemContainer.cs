using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemContainer : MonoBehaviour
{
    public ChaosRising.Item item;
    public bool draggable = false;

    [HideInInspector] public SpriteRenderer spriteRenderer;

    private void Start()
    {
        item = new ChaosRising.Item("inquisition");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Textures/" + item.sprite);
    }

    private void OnMouseDrag()
    {
        if (draggable)
        {
            transform.position = ChaosRising.MouseUtility.GetMousePosition();
            spriteRenderer.sortingLayerName = "UI";
        }
    }

    private void OnMouseUp()
    {        
        if (draggable)
        {
            spriteRenderer.sortingLayerName = "Item";
            draggable = false;
        }
    }

    public void SetParent(Transform parent, Vector3 offset)
    {
        transform.SetParent(parent);
        transform.position = parent.position + offset;
    }
}
