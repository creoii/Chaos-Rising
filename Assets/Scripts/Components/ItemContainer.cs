using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemContainer : MonoBehaviour
{
    public ChaosRising.Item item;
    public bool draggable = false;

    private Image image;

    private void Start()
    {
        item = new ChaosRising.Item("inquisition");

        image = GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Textures/" + item.sprite);
    }

    private void OnMouseDrag()
    {
        if (draggable)
        {
            transform.position = ChaosRising.MouseUtility.GetMousePosition();
        }
    }

    private void OnMouseUp()
    {
        if (draggable)
        {
            draggable = false;
        }
    }

    public void SetParent(Transform parent, Vector3 offset)
    {
        transform.SetParent(parent);
        transform.position = parent.position + offset;
    }
}
