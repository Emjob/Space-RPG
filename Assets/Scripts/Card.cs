using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int Heal;
    public int damage;
    public int speed;

    int con;

    public Camera myCam;

    private float startXPos;
    private float startYPos;

    private bool isDragging = false;

    CardSpawner Count;



    private void Start()
    {
        myCam = Camera.main;
        Count = GameObject.Find("Holder").GetComponent<CardSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("HELP");
        if (other.gameObject.tag == "Enemy" && damage > 0)
        {
            other.GetComponent<Collider>().GetComponent<Health>().EnemyTakeDamage(damage);
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && Heal > 0)
        {
            other.GetComponent<Collider>().GetComponent<Health>().PlayerHeal(Heal);
            Count.counter += 1;
            con += 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isDragging)
        {
            DragObject();
        }
        
        
    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;


        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.z - transform.localPosition.z;

        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }


    public void DragObject()
    {
        Vector3 mousePos = Input.mousePosition;



        mousePos = myCam.ScreenToWorldPoint(mousePos);
        transform.localPosition = new Vector3(mousePos.x - startXPos, 0, mousePos.z - startYPos);
    }
}
