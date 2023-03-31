using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler
{
    public int Heal;
    public int damage;
    public int speed;
    public int shield;

    private Vector2 mousePosition = new Vector2();
    private Vector2 startPosition = new Vector2();
    private Vector2 differencePoint = new Vector2();

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
        if (other.gameObject.tag == "Enemy" && damage > 0 && Single)
        {
            other.GetComponent<Collider>().GetComponent<Health>().hurt = true;
            other.GetComponent<Collider>().GetComponent<Health>().EnemyTakeDamage(damage);
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy" && damage > 0 && Splash)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Health>().Splash = true;
                enemies[i].GetComponent<Health>().SplashDamage(damage);
            }
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Enemy" && damage > 0 && Dot)
        {
            other.GetComponent<Collider>().GetComponent<Health>().Dot = true;
            other.GetComponent<Collider>().GetComponent<Health>().DamageOverTurn(damage);
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && Heal > 0 && Single)
        {
            other.GetComponent<Collider>().GetComponent<Health>().restore = true;
            other.GetComponent<Collider>().GetComponent<Health>().PlayerHeal(Heal);
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && Heal > 0 && DelayedHeal)
        {
            other.GetComponent<Collider>().GetComponent<Health>().DelayedHeal = true;
            other.GetComponent<Collider>().GetComponent<Health>().PreparedHeal(Heal);
            Count.counter += 1;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && shield > 0 && Single)
        {
            other.GetComponent<Collider>().GetComponent<Health>().getShield = true;
            other.GetComponent<Collider>().GetComponent<Health>().Shielded(shield);
            Count.counter += 1;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //if (isDragging)
        //{
        //    DragObject();
        //    collider.enabled = false;
        //}
        //if(!isDragging)
        //{
        //    collider.enabled = true;
        //}
        if (Input.GetMouseButton(0))
        {
            UpdateMousePosition();
        }
        if (Input.GetMouseButtonDown(0))
        {
            UpdateStartPosition();
            UpdateDifferencePoint();
        }
    }

    //private void OnMouseDown()
    //{
    //    Vector3 mousePos = Input.mousePosition;


    //    mousePos = myCam.ScreenToWorldPoint(mousePos);

    //    startXPos = mousePos.x - transform.localPosition.x;
    //    startYPos = mousePos.y - transform.localPosition.y;

    //    isDragging = true;
    //}

    //private void OnMouseUp()
    //{
    //    isDragging = false;

    //}


    //public void DragObject()
    //{
    //    Vector3 mousePos = Input.mousePosition;

    //    mousePos = myCam.ScreenToWorldPoint(mousePos);
    //    transform.localPosition = new Vector3(mousePos.x - startXPos, mousePos.y - startYPos, -162.8474f);
    //}


    public void OnDrag(PointerEventData eventData)
    {
        /*Minus the difference point so you can pick the 
        element from the edges, without any jerk*/

        transform.position = mousePosition - differencePoint;
    }

    private void UpdateMousePosition()
    {
        mousePosition.x = Input.mousePosition.x;
        mousePosition.y = Input.mousePosition.y;
    }

    private void UpdateStartPosition()
    {
        startPosition.x = transform.position.x;
        startPosition.y = transform.position.y;
    }

    private void UpdateDifferencePoint()
    {
        differencePoint = mousePosition - startPosition;
    }
}
