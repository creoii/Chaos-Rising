using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemContainer item;

    public Image image;

    public ItemContainer SetItem(ItemContainer item)
    {
        image.sprite = item.spriteRenderer.sprite;
        return this.item = item;
    }
}
