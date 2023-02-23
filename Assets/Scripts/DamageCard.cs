using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DamageCard : MonoBehaviour
{

    public int damage;

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
        if(other.gameObject.tag == "Enemy" )
        {
            other.GetComponent<Collider>().GetComponent<EnemyHealth>().TakeDamage(damage);
            Count.counter += 1;
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
