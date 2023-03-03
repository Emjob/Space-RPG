using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    public GameObject[] spawnPoint;
    public GameObject damageCard;
    public GameObject healthCard;
    public GameObject[] Deck;

   
    public Stats Health;
    TurnOrder change;

    public bool myTurn;
    public bool enemy1;
    public bool enemy2;
    public bool enemy3;
    public int counter;
    public int con;
    
    // Start is called before the first frame update
    void Start()
    {

        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();

        
       
    }

    // Update is called once per frame
    public void Update()
    {
        if (counter == 1)
        {
            change.changeTurn = true;
            counter = 0;
        }
    }

    public void Draw()
    {

        if (con < 5)
        {
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(Deck[Random.Range(0, Deck.Length)], spawnPoint[i].transform.position, Quaternion.identity);
                con += 1;
            }
        }
        
    }
}
