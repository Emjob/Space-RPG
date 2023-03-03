using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public bool isPlayerDead;
    public bool endTurn;
    public bool isEnemyDead;
    

    GameObject[] enemies = new GameObject[3];

    public HealthBar healthBar;
    public Stats baseStats;
    CardSpawner draw;
    TurnOrder change;
    enemyAttack turn;
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        currentHealth = baseStats.maxHealth;
        draw = GameObject.Find("Holder").GetComponent<CardSpawner>();
        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
        for (int i = 0; i < enemies.Length; i++)
        {
            turn = enemies[i].GetComponent<enemyAttack>();
        }


    }
    public void PlayerTakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isPlayerDead == false)
        {
            Destroy(gameObject);
            isPlayerDead = true;
        }
        healthBar.UpdateHealthBar();
 
    }
    public void PlayerHeal(int Heal)
    {
        if (currentHealth < baseStats.maxHealth)
        {
            currentHealth = currentHealth + Heal;
            healthBar.UpdateHealthBar();
        }
    }

    void HealthReset()
    {

    }

    public void EnemyTakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        if (currentHealth <= 0 && isEnemyDead == false)
        {
            Destroy(gameObject);
            isEnemyDead = true;

        }
        healthBar.UpdateHealthBar();
    }
    public void EnemyHeal(int Heal)
    {
        if (currentHealth < baseStats.maxHealth)
        {
            currentHealth = currentHealth + Heal;
            healthBar.UpdateHealthBar();
            GetComponent<Renderer>().material.color = new Color(255, 0, 211);
        }
    }

    private void Update()
    {
       
        if (endTurn == true)
        {
            change.changeTurn = true;
        }
    }

    public void Playerturn()
    {
        draw.con = 0;
        draw.Draw();
        
        if(draw.counter == 1)
        {
            change.changeTurn = true;
        }
    }
   
}
