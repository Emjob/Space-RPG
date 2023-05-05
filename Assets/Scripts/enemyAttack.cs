using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

    // public bool turnStart;

    public int damage;
    public int Heal;

    public bool myturn;

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
    public void Update()
    {
        if (myturn == true)
        {
               int n = Random.Range(0, 2);
            Debug.Log("ahahahdosidfijearngouiesarg");
            if (n == 0)
            {
                Anim.SetBool("isAttacking1", true);
                StartCoroutine(ExecuteAfterHurt(Anim.GetCurrentAnimatorStateInfo(0).length));
            }

            if (n == 1)
            {
                Anim.SetBool("isShakir_Heal", true);
                StartCoroutine(ExecuteAfterHeal(Anim.GetCurrentAnimatorStateInfo(0).length));

            }
            change.i += 1;
            myturn = false;

        }


    }
    IEnumerator ExecuteAfterHurt(float time)
    {
        yield return new WaitForSeconds(time);

        players[Random.Range(0, players.Length)].GetComponent<Health>().PlayerTakeDamage(damage);
        Debug.Log("Attack");
        
        
        Anim.SetBool("isAttacking1", false);
        //   GetComponent<Renderer>().material.color = new Color(255, 0, 0);

    }
    IEnumerator ExecuteAfterHeal(float time)
    {
        yield return new WaitForSeconds(time);

        GetComponent<Health>().EnemyHeal(Heal);
        //   GetComponent<Renderer>().material.color = new Color(255, 0, 211);
        Debug.Log("Heal");
        
        
        Anim.SetBool("isShakir_Heal", false);

    }
}
