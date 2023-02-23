using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 20;
    public bool isPlayerDead = false;

    public PlayerHealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isPlayerDead == false)
        {
            Destroy(gameObject);
            isPlayerDead = true;
        }
        healthBar.UpdateHealthBar();
    }
    public void Heal(int Heal)
    {
        
            currentHealth = currentHealth + Heal;
            healthBar.UpdateHealthBar();
        
    }
}
