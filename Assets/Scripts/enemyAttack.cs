using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

   // public bool turnStart;

    public int damage;
    public int Heal;

    Animator Anim;

    TurnOrder change;

   public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
        players = GameObject.FindGameObjectsWithTag("Player");
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void EnemyTurn()
    {
        
        int n = Random.Range(0, 2);
            if(n == 0)
            {
            Anim.SetBool("isAttacking1", true);
            StartCoroutine(ExecuteAfterHurt(Anim.GetCurrentAnimatorStateInfo(0).length));
        }
            if(n == 1)
            {
            Anim.SetBool("isHeal", true);
            StartCoroutine(ExecuteAfterHeal(Anim.GetCurrentAnimatorStateInfo(0).length));
            Anim.SetBool("isHeal", false);
            GetComponent<Health>().EnemyHeal(Heal);
            GetComponent<Renderer>().material.color = new Color(255, 0, 211);
            Debug.Log("Heal");
        }

       

    }
    IEnumerator ExecuteAfterHurt(float time)
    {
        
        yield return new WaitForSeconds(time);
        Anim.SetBool("isAttacking1", false);
        players[Random.Range(0, 2)].GetComponent<Health>().PlayerTakeDamage(damage);
        Debug.Log("Attack");
        GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        // Code to execute after the delay
    }
    IEnumerator ExecuteAfterHeal(float time)
    {

        yield return new WaitForSeconds(time);
        Anim.SetBool("isAttacking1", false);
        players[Random.Range(0, 2)].GetComponent<Health>().PlayerTakeDamage(damage);
        Debug.Log("Attack");
        GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        // Code to execute after the delay
    }
}
