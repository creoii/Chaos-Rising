using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(StatContainer))]
public class Living : MonoBehaviour
{
    public int health, magic;

    [HideInInspector] public ChaosRising.Stats stats;
    [HideInInspector] public Dictionary<int, Action> statBars = new Dictionary<int, Action>();

    private void Awake()
    {
        stats = GetComponent<StatContainer>().stats;

        health = stats.maxHealth;
        magic = stats.maxMagic;
    }

    private void OnEnable()
    {
        if (stats != null)
        {
            health = stats.maxHealth;
            magic = stats.maxMagic;
        }
    }

    public void Damage(int amount)
    {
        if (health - amount <= 0)
        {
            Kill();
        }
        else health -= amount;

        if (statBars.ContainsKey(0))
        {
            statBars[0].Invoke();
        }
    }

    public void Damage(int amount, int armorIgnored)
    {
        if (armorIgnored >= stats.armor) amount += stats.armor;
        else amount += armorIgnored;

        Damage(amount);
    }

    private void Kill()
    {
        health = 0;
        gameObject.SetActive(false);
    }
}
