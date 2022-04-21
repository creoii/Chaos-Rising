using System;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    public Vector2 baseSize;
    public int stat;

    public Living living;
    public RectTransform rectTransform;

    private void Start()
    {
        living = GetComponentInParent<Living>();
        rectTransform = GetComponentInParent<RectTransform>();

        switch(stat)
        {
            case 0:
                living.statBars.Add(stat, () => MaxHealth());
                break;
            case 1:
                living.statBars.Add(stat, () => MaxMagic());
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }

    private void MaxHealth()
    {
        rectTransform.sizeDelta = baseSize + (Vector2.right * (living.health - 200f) * .5f);
    }

    private void MaxMagic()
    {
        rectTransform.sizeDelta = baseSize + (Vector2.right * (living.magic - 200f) * .5f);
    }
}
