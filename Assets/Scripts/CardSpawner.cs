using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    public GameObject[] spawnPoint;
    public GameObject damageCard;
    List<Transform> cardPosition = new List<Transform>();

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(damageCard, spawnPoint[i].transform.position, Quaternion.identity);
        }

        //  Instantiate(damageCard,parents[1]);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
