using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{

   // public bool turnStart;

    public int damage;
    public int Heal;

    TurnOrder change;
    // Start is called before the first frame update
    void Start()
    {
        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
    }

    // Update is called once per frame
    public void EnemyTurn()
    {
        
        int n = Random.Range(0, 2);
            if(n == 0)
            {
                GameObject.Find("Player").GetComponent<Health>().PlayerTakeDamage(damage);
            GetComponent<Renderer>().material.color = new Color(255, 0, 0);

        }
            if(n == 1)
            {
                GetComponent<Health>().EnemyHeal(Heal);
               
        }
        


    }
}
