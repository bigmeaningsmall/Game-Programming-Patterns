using System;
using UnityEngine;

public class HealthModel : MonoBehaviour
{
    public event Action<int, int> HealthChanged; // (current, max)

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int startHealth = 100;

    public int MaxHealth => maxHealth;
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        startHealth = Mathf.Clamp(startHealth, 0, maxHealth);
        CurrentHealth = startHealth;
        Raise();
    }

    public void Heal(int amount)
    {
        if (amount <= 0) return;
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, maxHealth);
        Raise();
    }

    public void Damage(int amount)
    {
        if (amount <= 0) return;
        CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, maxHealth);
        Raise();
    }

    public void Restore()
    {
        CurrentHealth = maxHealth;
        Raise();
    }

    private void Raise() => HealthChanged?.Invoke(CurrentHealth, maxHealth);
}