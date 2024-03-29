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
    private int gainShield;
    public int turnCount;
    public int turnCounting;

    public bool isPlayerDead;
    public bool isEnemyDead;
    public bool hurt;
    public bool restore;
    public bool myturn;
    public bool Dot;
    public bool DelayedHeal;
    public bool Splash;
    public bool getShield;

    Collider Collider;
    public Animator Anim;
    

    GameObject[] enemies = new GameObject[3];

    public HealthBar healthBar;
    public Stats baseStats;
    private void Start()
    {
        Collider = GetComponent<Collider>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        currentHealth = baseStats.maxHealth;

        DotTurns = 2;

        Anim = gameObject.GetComponent<Animator>();

    }
    public void PlayerTakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        Anim.SetBool("isHit", true);
        if (currentHealth <= 0 && isPlayerDead == false)
        {
            Destroy(gameObject);
            isPlayerDead = true;
        }
        Anim.SetBool("isHit", false);
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

    public void Shielded(int shield)
    {
        gainShield = shield;
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
        if (currentHealth <= 0 && isEnemyDead == false)
        {
            //   Destroy(gameObject);
            Anim.SetBool("isDead", true);
            isEnemyDead = true;

        }


        //if (myturn == true)
        //{
        //    if (turnCount == DotTurns)
        //    {
        //        damageOverTurn = 0;
        //        Dot = false;
        //    }
        //    if (turnCounting == DotTurns)
        //    {
        //        getShield = false;
        //        currentHealth = currentHealth - gainShield;
        //        gainShield = 0;
        //    }
        //    Collider.enabled = true;
        //    if(currentHealth > baseStats.maxHealth)
        //    {
        //        currentHealth = baseStats.maxHealth;
        //    }
        //    if (restore == true && myturn == true)
        //    {
                
        //        if (currentHealth < baseStats.maxHealth)
        //        {
        //            currentHealth = currentHealth + healOnTurn;
        //            healthBar.UpdateHealthBar();
        //        }
        //        healOnTurn = 0;
                 
        //    }
        //    if (DelayedHeal == true && myturn == true)
        //    {
        //        if(delay > 1)
        //        {
        //            delay = 0;
        //        }
        //        if (currentHealth < baseStats.maxHealth && delay == 1)
        //        {
        //            currentHealth = currentHealth + healOnDelay;
        //            healthBar.UpdateHealthBar();
        //            healOnDelay = 0;
                    
        //        }
        //        delay += 1;
                
        //    }
        //    if (hurt == true && myturn == true)
        //    {
        //        Anim.SetBool("isHit", true);
        //        StartCoroutine(ExecuteAfterTime(Anim.GetCurrentAnimatorStateInfo(0).length));
        //        Anim.SetBool("isHit", false);
        //        currentHealth = currentHealth - damageOnTurn;
                
        //        healthBar.UpdateHealthBar();
        //        damageOnTurn = 0;
                
                
        //    }
        //    if (Splash == true && myturn == true)
        //    {
        //        Anim.SetBool("isHit", true);
        //        StartCoroutine(ExecuteAfterTime(Anim.GetCurrentAnimatorStateInfo(0).length));
        //        Anim.SetBool("isHit", false);
        //        currentHealth = currentHealth - splash;
                
        //        healthBar.UpdateHealthBar();
        //        splash = 0;
                
                
        //    }
        //    if (Dot == true && myturn == true)
        //    {
        //        Anim.SetBool("isHit", true);
        //        StartCoroutine(ExecuteAfterTime(Anim.GetCurrentAnimatorStateInfo(0).length));
        //        Anim.SetBool("isHit", false);
        //        currentHealth = currentHealth - damageOverTurn;
                
        //        healthBar.UpdateHealthBar();
                
        //        turnCount += 1;
                
        //    }
        //    if (getShield == true && myturn == true)
        //    {
                
        //        currentHealth = currentHealth + gainShield;
        //                turnCounting += 1;  
        //    }
        //   
        //}
        

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Card" && gameObject.tag == "Player")
        {
            Collider.enabled = false;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
    }

}
