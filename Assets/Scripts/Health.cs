using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public bool isPlayerDead = false;
    public bool turnStart;
    public bool endTurn;

    public PlayerHealthBar healthBar;
    public Stats baseStats;
     CardSpawner draw;
     TurnOrder change;
    private void Start()
    {
        currentHealth = baseStats.maxHealth;
         draw =  GameObject.Find("Holder").GetComponent<CardSpawner>();
            change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
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

    private void Update()
    {
        if (turnStart == true)
        {
            draw.Draw();
        }
        if (endTurn == true)
        {
            change.changeTurn = true;
        }
    }

}
