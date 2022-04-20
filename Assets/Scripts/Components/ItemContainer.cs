using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemContainer : MonoBehaviour
{
    public ChaosRising.Item item;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        item = new ChaosRising.Item("inquisition");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Textures/Items/" + item.sprite);
    }
}
