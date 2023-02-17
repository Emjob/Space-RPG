using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCard : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HELP");
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Collider>().GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
