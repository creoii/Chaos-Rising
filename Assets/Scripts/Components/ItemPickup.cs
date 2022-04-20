using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
    }

    public void Pickup(ItemContainer itemContainer)
    {
        itemContainer.draggable = true;
        inventory.AddItem(inventory.transform, itemContainer);
    }
}
