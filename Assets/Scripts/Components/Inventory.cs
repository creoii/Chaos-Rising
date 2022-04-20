using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int size;

    public Image[] slots;
    public List<ItemContainer> items;

    private void Start()
    {
        slots = new Image[size];
        items = new List<ItemContainer>();
        for (int i = 0; i < size; ++i)
        {
            slots[i] = transform.GetChild(i).GetComponent<Image>();
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
            item.SetParent(parent, Vector3.zero);
            SpriteUtility.SetSprite(slots[index], "Textures/" + item.item.sprite);
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
                item.SetParent(parent, Vector3.zero);
                SpriteUtility.SetSprite(slots[i], "Textures/" + item.item.sprite);
                items[i] = item;
            }
        }
    }
}
