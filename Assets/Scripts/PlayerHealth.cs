using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 20;
    public bool isPlayerDead = false;

    public void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isPlayerDead == false)
        {
            Destroy(gameObject);
            isPlayerDead = true;
        }
    }
}
