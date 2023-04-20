using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour, IDropHandler
{

    mouseDetect acuire;

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
    public int turnCounting;

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
        if (Splash == true || Attack == true || Dot == true)
        {
            isAttacking = true;

        }
        if (isAttacking == true && myturn == true)
        {
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteAfterTime(Anim.GetCurrentAnimatorStateInfo(0).length));
            
        }
        if(DelayedHeal || restore || getShield)
        {
            isHealing = true;
        }
        if(isHealing && myturn)
        {
            Collider.enabled = true;
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteAfterTime(Anim.GetCurrentAnimatorStateInfo(0).length));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (Splash == true)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Health>().currentHealth -= splashDamage;
            }
            splashDamage = 0;
            Splash = false;
        }
        if (Attack == true)
        {
            recievedDamage.GetComponent<Health>().currentHealth -= instDamage;
            instDamage = 0;
            Attack = false;
        }
        if (Dot)
        {
            if (turnCount >= 0)
            {
                recievedDOT.GetComponent<Health>().currentHealth -= DOT;
                turnCount -= 1;
            }
            if (turnCount <= 0)
            {
                DOT = 0;
                Dot = false;
            }
            if(DelayedHeal)
            {
                if(delay >= 0)
                {
                    delay -= 1;
                }
                if (delay == 0 && GetComponent<Health>().currentHealth < GetComponent<Stats>().maxHealth)
                {
                    GetComponent<Health>().currentHealth += healOnDelay;
                    healOnDelay = 0;
                    DelayedHeal = false;
                }

            }
            if(restore && GetComponent<Health>().currentHealth < GetComponent<Stats>().maxHealth)
            {
                GetComponent<Health>().currentHealth += Healing;
                restore = false;
                Healing = 0;
            }
            if(getShield)
            {
                GetComponent<Health>().currentHealth += Shielding;
                Shielding = 0;
                getShield = false;
            }
            Anim.SetBool("isAttacking1", false);
            // Code to execute after the delay
            myturn = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
}

