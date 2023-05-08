using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseDetect : MonoBehaviour
{
    private Camera camera;

    public GameObject target;

    GameObject[] state;

    CardSpawner Count;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        Count = GameObject.Find("Holder").GetComponent<CardSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        state = GameObject.FindGameObjectsWithTag("Player");   
        if(Count.counter == Count.players.Length)
        {
            target = null;
        }
    }

    public void DetectObjectWithRaycast()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Count.counter += 1;
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);
                if (hit.collider.CompareTag("Enemy"))
                {
                    target = hit.collider.gameObject;
                }
                
                for(int i = 0; i < state.Length; i ++)
                {
                    state[i].GetComponent<PlayerAttack>().isTargeting = false;
                }
            }
        }
    }
}
