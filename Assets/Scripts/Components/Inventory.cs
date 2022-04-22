using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class Inventory : MonoBehaviour
{
    public int size;

    public GridLayoutGroup gridLayout;
    public GameObject slotPrefab;
    private List<Slot> slots;

    private void Start()
    {
        slots = new List<Slot>();
        for (int i = 0; i < size; ++i)
        {
            slots.Add(Instantiate(slotPrefab, transform).GetComponent<Slot>());
        }

        gridLayout = GetComponent<GridLayoutGroup>();
    }

    public ItemContainer GetItem(int index)
    {
        return slots[index].item;
    }

    public ItemContainer SetItem(int index, Transform parent, ItemContainer item)
    {
        if (index >= 0 && index < slots.Count)
        {
            return slots[index].SetItem(item);
        }
        return item;
    }

    public void AddItem(Transform parent, ItemContainer item)
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            if (slots[i] == null)
            {
                slots[i].SetItem(item);
            }
        }
    }
}
