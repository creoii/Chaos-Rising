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
        inventory.AddItem(inventory.transform, itemContainer);
    }
}
