using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float currentHealth;
    public float maxHealth = 20;
    public bool isEnemyDead = false;

    public EnemyHealthBar healthBar;

    public void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if(currentHealth <= 0 && isEnemyDead == false)
        {
            Destroy(gameObject);
            isEnemyDead = true;

        }
        healthBar.UpdateHealthBar();
    }    
    public void Heal(int Heal)
    {
        currentHealth = currentHealth + Heal;
        healthBar.UpdateHealthBar();
    }
}
