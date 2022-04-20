using UnityEngine;

[RequireComponent(typeof(StatContainer))]
public class Living : MonoBehaviour
{
    public int health;
    public int magic;

    private StatContainer stats;

    private void Start()
    {
        stats = GetComponent<StatContainer>();

        health = stats.stats.maxHealth;
        magic = stats.stats.maxMagic;
    }

    public void Damage(int amount, int armorIgnored)
    {
        if (armorIgnored > 0)
        {
            if (armorIgnored >= stats.stats.armor) amount += stats.stats.armor;
            else amount += armorIgnored;
        }

        if (health - amount < 0)
        {
            Kill();
        }
        else health -= amount;
    }

    private void Kill()
    {
        health = 0;
        gameObject.SetActive(false);
    }
}
