using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int size;

    public List<ItemContainer> items;

    private void Start()
    {
        items = new List<ItemContainer>();
        for (int i = 0; i < size; ++i)
        {
            items.Add(null);
        }
    }

    public ItemContainer GetItem(int index)
    {
        return items[index];
    }

    public ItemContainer SetItem(int index, Transform parent, ItemContainer item)
    {
        if (index >= 0 && index < items.Count)
        {
            item.transform.SetParent(parent);
            return items[index] = item;
        }
        return item;
    }

    public void AddItem(Transform parent, ItemContainer item)
    {
        for (int i = 0; i < items.Count; ++i)
        {
            if (items[i] == null)
            {
                item.transform.SetParent(parent);
                items[i] = item;
            }
        }
    }
}
