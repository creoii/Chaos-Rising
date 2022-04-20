using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class ItemPickup : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    public void Pickup(Transform parent, ItemContainer itemContainer)
    {
        inventory.AddItem(parent, itemContainer);
    }
}
