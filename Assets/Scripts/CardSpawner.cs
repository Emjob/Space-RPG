using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    GameObject[] spawnPoint;
    public GameObject[] Deck;
    public GameObject[] activeDeck = new GameObject[15];
    GameObject[] RemainingCards;

   
    public Stats Health;
    TurnOrder change;

    public bool spawn;


    public int counter;
    public int con;
    public int shuffle;
    private int j;
    
    // Start is called before the first frame update
    void Start()
    {

        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int i = 0; i < 15; i++)
        {
            activeDeck[i] = Deck[Random.Range(0, Deck.Length)];
        }

    }

    // Update is called once per frame
    public void Update()
    {
       

        RemainingCards = GameObject.FindGameObjectsWithTag("Card");
        if (counter == 3)
        {
            for(int i = 0; i < RemainingCards.Length; i++)
            {
                Destroy(RemainingCards[i]);
            }
            change.changeTurn = true;
            counter = 0;
        }
    }

    public void Draw()
    {
       con = 0;
        if (con < 5)
        {
            if (j >= activeDeck.Length)
            {
                j = 0;
                for (int z = 0; z < 15; z++)
                {
                    activeDeck[z] = Deck[Random.Range(0, Deck.Length)];
                }
            }
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                
                Instantiate(activeDeck[j], spawnPoint[i].transform.position, Quaternion.identity);
                //  activeDeck.RemoveAt(i);
                    j += 1;
                    con += 1;
                
            }
        }
            
    }
       // if(counter == 1)
       // {
       //     change.changeTurn = true;
       // }
        
}

