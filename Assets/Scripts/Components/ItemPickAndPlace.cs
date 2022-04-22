using UnityEngine;

public class ItemPickAndPlace : MonoBehaviour
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
