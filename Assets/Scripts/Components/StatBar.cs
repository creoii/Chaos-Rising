using System;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    public Vector2 baseSize;
    public int stat;

    public Living living;
    public RectTransform rectTransform;

    private Action action;

    private void Start()
    {
        living = GetComponentInParent<Living>();
        rectTransform = GetComponentInParent<RectTransform>();

        switch(stat)
        {
            case 0:
                action = () => MaxHealth();
                break;
            case 1:
                action = () => MaxMagic();
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

    private void Update()
    {
        action.Invoke();
    }

    private void MaxHealth()
    {
        if (living.stats.stats.maxHealth > 100)
        {
            rectTransform.sizeDelta = baseSize + (Vector2.right * (living.stats.stats.maxHealth - 100f) * .5f);
        }
    }

    private void MaxMagic()
    {
        if (living.stats.stats.maxMagic > 100)
        {
            rectTransform.sizeDelta = baseSize + (Vector2.right * (living.stats.stats.maxMagic - 100f) * .5f);
        }
    }
}
