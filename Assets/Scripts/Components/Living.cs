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

    private void OnEnable()
    {
        if (stats != null)
        {
            health = stats.stats.maxHealth;
            magic = stats.stats.maxMagic;
        }
    }

    public void Damage(int amount)
    {
        if (health - amount <= 0)
        {
            Kill();
        }
        else health -= amount;
    }

    public void Damage(int amount, int armorIgnored)
    {
        if (armorIgnored >= stats.stats.armor) amount += stats.stats.armor;
        else amount += armorIgnored;

        Damage(amount);
    }

    private void Kill()
    {
        health = 0;
        gameObject.SetActive(false);
    }
}
