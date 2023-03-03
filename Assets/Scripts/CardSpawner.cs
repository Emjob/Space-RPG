using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{

    GameObject[] spawnPoint;
    public GameObject damageCard;
    public GameObject healthCard;
    public GameObject[] Deck;
    public GameObject[] activeDeck = new GameObject[15];
    GameObject[] RemainingCards;

   
    public Stats Health;
    TurnOrder change;

    public bool myTurn;
   

    public int counter;
    public int con;
    public int shuffle;
    
    // Start is called before the first frame update
    void Start()
    {

        change = GameObject.Find("TurnChanger").GetComponent<TurnOrder>();
        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int i = 0; i < activeDeck.Length; i++)
        {
            activeDeck[i] = Deck[Random.Range(0, 2)];
        }

    }

    // Update is called once per frame
    public void Update()
    {
       

        RemainingCards = GameObject.FindGameObjectsWithTag("Card");
        if (counter == 1)
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
            for (int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(Deck[Random.Range(0, Deck.Length)], spawnPoint[i].transform.position, Quaternion.identity);
                con += 1;
            }
        }
       // if(counter == 1)
       // {
       //     change.changeTurn = true;
       // }
        
    }
}
