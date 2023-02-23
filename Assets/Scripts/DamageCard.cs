using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DamageCard : MonoBehaviour
{

    public int damage;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HELP");
        if(other.gameObject.tag == "Enemy" )
        {
            other.GetComponent<Collider>().GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
