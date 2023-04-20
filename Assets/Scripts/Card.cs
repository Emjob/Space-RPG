using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    public int Heal;
    public int damage;
    public int speed;
    public int shield;

    public int timer;
    

    //  int con;

    public Camera myCam;

    private float startXPos;
    private float startYPos;

    private bool isDragging = false;
    public bool Splash;
    public bool Single;
    public bool Dot;
    public bool DelayedHeal;

    new Collider collider;

    CardSpawner Count;

    GameObject[] enemies = new GameObject[3];

    private void Start()
    {
        collider = GetComponent<Collider>();
        myCam = Camera.main;
        Count = GameObject.Find("Holder").GetComponent<CardSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("HELP");
        
        if (damage > 0 && Single)
        {
            other.GetComponent<PlayerAttack>().isTargeting = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().Attack = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().instDamage += damage;
            
            Destroy(gameObject);
        }
        if (damage > 0 && Splash)
        {
            other.GetComponent<PlayerAttack>().isTargeting = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().Splash = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().splashDamage += damage;
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (damage > 0 && Dot)
        {
            other.GetComponent<PlayerAttack>().isTargeting = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().Dot = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().turnCount += timer;
            if(other.GetComponent<Collider>().GetComponent<PlayerAttack>().turnCount == 0)
            {
             other.GetComponent<Collider>().GetComponent<PlayerAttack>().DOT += damage;
            }

            Destroy(gameObject);
        }
        if (Heal > 0 && Single)
        {
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().restore = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().Healing += Heal;
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (Heal > 0 && DelayedHeal)
        {
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().DelayedHeal = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().healOnDelay += Heal;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().delay += timer;
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (shield > 0 && Single)
        {
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().getShield = true;
            other.GetComponent<Collider>().GetComponent<PlayerAttack>().Shielding += shield;
            Count.counter += 1;
            Destroy(gameObject);
        }
    }


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (isDragging)
        {
            DragObject();
            collider.enabled = false;
        }
        if (!isDragging)
        {
            collider.enabled = true;
        }

    }

    private void OnMouseDown()
    {
        Vector3 mousePos = Input.mousePosition;


        mousePos = myCam.ScreenToWorldPoint(mousePos);

        startXPos = mousePos.x - transform.localPosition.x;
        startYPos = mousePos.y - transform.localPosition.y;

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
        transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, -162.8474f);
    }



}
