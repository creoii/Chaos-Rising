using UnityEngine;

public class StatBar : MonoBehaviour
{
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
                rectTransform.sizeDelta = new Vector2(living.health * .5f, 10f); 
                living.statBars.Add(stat, () => MaxHealth());
                break;
            case 1:
                rectTransform.sizeDelta = new Vector2(living.magic * .5f, 10f);
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
        rectTransform.sizeDelta = new Vector2(living.health * .5f, 10f);
    }

    private void MaxMagic()
    {
        rectTransform.sizeDelta = new Vector2(living.magic * .5f, 10f);
    }
}
