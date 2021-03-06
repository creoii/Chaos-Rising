using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemContainer : MonoBehaviour
{
    public ChaosRising.Item item;

    [HideInInspector] public SpriteRenderer spriteRenderer;

    private void Start()
    {
        item = new ChaosRising.Item("inquisition", "");

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ChaosRising.AssetManager.GetItemSprite(item.sprite);
    }

    public void SetParent(Transform parent, Vector3 offset)
    {
        transform.SetParent(parent);
        transform.position = parent.position + offset;
    }
}
