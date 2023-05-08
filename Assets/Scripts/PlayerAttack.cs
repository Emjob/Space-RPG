using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour, IDropHandler
{

    mouseDetect acuire;
    TurnOrder turn;
    CardSpawner Count;

    public GameObject recievedDamage;
    public GameObject recievedDOT;
  //  public GameObject recievedHealth;

    public int DOT;
    public int splashDamage;
    public int instDamage;

    public int Healing;
    public int Shielding;
    public int healOnDelay;

    //  public int DotTurns;

    public int delay;
    public int turnCount;
    public int actions;
    public int totalActions;

    public bool isAttacking;
    public bool isTargeting;
    public bool isHealing;
    public bool isPlayerDead;

    public bool Attack;
    public bool restore;
    public bool myturn;
    public bool Dot;
    public bool DelayedHeal;
    public bool Splash;
    public bool getShield;

    Collider Collider;
    Animator Anim;

    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        acuire = GameObject.Find("Dectector").GetComponent<mouseDetect>();
        turn = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
        Count = GameObject.Find("Holder").GetComponent<CardSpawner>();
        Collider = GetComponent<Collider>();
        Anim = gameObject.GetComponent<Animator>();
        
    }

    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (isTargeting == true && Attack == true)
        {
            acuire.DetectObjectWithRaycast();
            recievedDamage = acuire.target;
        }
        
        if (isTargeting == true && Dot == true)
        {
            acuire.DetectObjectWithRaycast();
            recievedDOT = acuire.target;
        }
        if(Count.counter == Count.players.Length)
        {
            isTargeting = false;
        }
        if(myturn)
        {
            isTargeting = false;
        }
        if (Splash == true && myturn == true)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteSplash(Anim.GetCurrentAnimatorStateInfo(0).length));
            
        }
        if (Attack == true && myturn == true)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteAttack(Anim.GetCurrentAnimatorStateInfo(0).length));

        }
        if (Dot == true && myturn == true)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteDOT(Anim.GetCurrentAnimatorStateInfo(0).length));

        }
        if(DelayedHeal && myturn)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteDelayedHeal(Anim.GetCurrentAnimatorStateInfo(0).length));
        }
        if (restore && myturn)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteRestore(Anim.GetCurrentAnimatorStateInfo(0).length));
        }
        if (getShield && myturn)
        {
            
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteShield(Anim.GetCurrentAnimatorStateInfo(0).length));
        }

        if(actions >= totalActions && myturn == true)
        {
            recievedDamage = null;
            turn.i += 1;
            totalActions = 0;
            actions = 0;
            myturn = false;
        }
        
}

    IEnumerator ExecuteSplash(float time)
    {
        yield return new WaitForSeconds(time);
     
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Health>().currentHealth -= splashDamage;
            enemies[i].GetComponent<Health>().healthBar.UpdateHealthBar();
            enemies[i].GetComponent<Health>().Anim.SetBool("isHit", true);
            enemies[i].GetComponent<Health>().Anim.SetBool("isHit", false);
        }
        splashDamage = 0;
        Splash = false;
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }
    IEnumerator ExecuteDOT(float time)
    {
        yield return new WaitForSeconds(time);
        
        if (turnCount >= 0)
            {
                recievedDOT.GetComponent<Health>().currentHealth -= DOT;
            recievedDOT.GetComponent<Health>().healthBar.UpdateHealthBar();
            turnCount -= 1;
            recievedDOT.GetComponent<Health>().Anim.SetBool("isHit", true);
            recievedDOT.GetComponent<Health>().Anim.SetBool("isHit", false);
        }
            if (turnCount <= 0)
            {
                DOT = 0;
                Dot = false;
            }
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }
    IEnumerator ExecuteAttack(float time)
    {
        yield return new WaitForSeconds(time);
        
        recievedDamage.GetComponent<Health>().currentHealth -= instDamage;
        recievedDamage.GetComponent<Health>().healthBar.UpdateHealthBar();
        recievedDamage.GetComponent<Health>().Anim.SetBool("isHit", true);
        recievedDamage.GetComponent<Health>().Anim.SetBool("isHit", false);
        instDamage = 0;
            Attack = false;
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }
    IEnumerator ExecuteDelayedHeal(float time)
    {
        yield return new WaitForSeconds(time);
        
        if (delay >= 0)
        {
            delay -= 1;
        }
        if (delay == 0 && GetComponent<Health>().currentHealth < GetComponent<Stats>().maxHealth)
        {
            GetComponent<Health>().currentHealth += healOnDelay;
            healOnDelay = 0;
            DelayedHeal = false;
        }
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }
    IEnumerator ExecuteRestore(float time)
    {
        yield return new WaitForSeconds(time);
       
        GetComponent<Health>().currentHealth += Healing;
        restore = false;
        Healing = 0;
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }
    IEnumerator ExecuteShield(float time)
    {
        yield return new WaitForSeconds(time);
        
        GetComponent<Health>().currentHealth += Shielding;
        Shielding = 0;
        getShield = false;
        actions += 1;
        Anim.SetBool("isAttacking1", false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}

