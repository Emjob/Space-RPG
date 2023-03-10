using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float healOnTurn;
    public float damageOnTurn;

    public int damageOverTurn;
    public int DotTurns;
    public int healOnDelay;
    public int splash;
    private int delay;

    public bool isPlayerDead;
    public bool endTurn;
    public bool isEnemyDead;
    public bool hurt;
    public bool restore;
    public bool myturn;
    public bool Dot;
    public bool DelayedHeal;
    public bool Splash;

    Collider Collider;
    

    GameObject[] enemies = new GameObject[3];

    public HealthBar healthBar;
    public Stats baseStats;
    private void Start()
    {
        Collider = GetComponent<Collider>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        currentHealth = baseStats.maxHealth;

       


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
            healOnTurn = Heal; 
    }
    public void PreparedHeal(int Heal)
    {
        healOnDelay = Heal;
    }


    public void EnemyTakeDamage(int damage)
    {

            damageOnTurn = damage;  
    }
    public void SplashDamage(int damage)
    {
        splash += damage;
    }

    public void DamageOverTurn(int damage)
    {
        
            damageOverTurn = damage;
       
    }
    public void EnemyHeal(int Heal)
    {
        if (currentHealth < baseStats.maxHealth)
        {
            currentHealth = currentHealth + Heal;
            healthBar.UpdateHealthBar();
            
        }
    }

    private void Update()
    {

        
        if(myturn == true)
        {
            Collider.enabled = true;
            if(currentHealth > baseStats.maxHealth)
            {
                currentHealth = baseStats.maxHealth;
            }
            if (restore == true && myturn == true)
            {
                if (currentHealth < baseStats.maxHealth)
                {
                    currentHealth = currentHealth + healOnTurn;
                    healthBar.UpdateHealthBar();
                }
                healOnTurn = 0;
                restore = false; 
            }
            if (DelayedHeal == true && myturn == true)
            {
                if(delay > 1)
                {
                    delay = 0;
                }
                if (currentHealth < baseStats.maxHealth && delay == 1)
                {
                    currentHealth = currentHealth + healOnDelay;
                    healthBar.UpdateHealthBar();
                    healOnDelay = 0;
                    DelayedHeal = false;
                }
                delay += 1;
                
            }
            if (hurt == true && myturn == true)
            {
                currentHealth = currentHealth - damageOnTurn;
                if (currentHealth <= 0 && isEnemyDead == false)
                {
                    Destroy(gameObject);
                    isEnemyDead = true;

                }
                healthBar.UpdateHealthBar();
                damageOnTurn = 0;
                hurt = false;
            }
            if (Splash == true && myturn == true)
            {
                currentHealth = currentHealth - splash;
                if (currentHealth <= 0 && isEnemyDead == false)
                {
                    Destroy(gameObject);
                    isEnemyDead = true;

                }
                healthBar.UpdateHealthBar();
                splash = 0;
                Splash = false;
            }
            if (Dot == true && myturn == true)
            {
                currentHealth = currentHealth - damageOverTurn;
                if (currentHealth <= 0 && isEnemyDead == false)
                {
                    Destroy(gameObject);
                    isEnemyDead = true;

                }
                healthBar.UpdateHealthBar();
                int turnCount = 0;
                turnCount += 1;
                if(turnCount == DotTurns)
                {
                    damageOverTurn = 0;
                    Dot = false;
                }
                
            }
            myturn = false;
        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Card")
        {
            Collider.enabled = false;
        }
    }

}
