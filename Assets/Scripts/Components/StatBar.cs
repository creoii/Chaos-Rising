using UnityEngine;

public class StatBar : MonoBehaviour
{
    public Vector2 baseSize;

    public Living living;
    public RectTransform rectTransform;

    private void Start()
    {
        living = GetComponentInParent<Living>();
        rectTransform = GetComponentInParent<RectTransform>();
    }

    private void Update()
    {
        if (living.stats.stats.maxHealth > 100)
        {
            rectTransform.sizeDelta = baseSize + (Vector2.right * (living.stats.stats.maxHealth - 100f) * .25f);
        }
    }
}
