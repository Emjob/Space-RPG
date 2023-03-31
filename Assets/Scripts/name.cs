using UnityEngine;
using System.Collections;

public class name : MonoBehaviour
{
    public static string PlayerName = "Player";
    public Camera cam;
    public string rep = "player";
    public string line2 = "A Player Object";
    public float offset = 0;
    public float offsetHor = 0;
    public static bool showNameplate = true;
    void Start()
    {
        cam = Camera.main;
    }

    void OnGUI()
    {
        Transform parent = transform.root;
        PlayerName = parent.name;
        Vector3 pos = cam.WorldToScreenPoint(transform.position);
        GUIStyle style = new GUIStyle();

        switch (rep)
        {
            case "defensive":
                style.normal.textColor = Color.yellow; //Is Defensive! 
                break;
            case "offensive":
                style.normal.textColor = Color.red; //Is Offensive!
                break;
            case "player":
                style.normal.textColor = Color.cyan; //Is Player!  
                break;
            default:
                style.normal.textColor = Color.green; //Is Friendly!   
                break;
        }
        float distance = Vector3.Distance(transform.position, GameObject.Find("player").transform.position);
        if (distance > 50.00)
        {
            //Hide the nameplate.
            showNameplate = false;
        }
        else
        {
            showNameplate = true;
        }
        if (transform.GetComponent<Renderer>().isVisible == true)
        {
            showNameplate = true;
        }
        else
        {
            showNameplate = false;
        }

        if (showNameplate == true)
        {
            style.fontSize = 20;
            float width = parent.name.Length * 10;
            GUI.Label(new Rect(pos.x - (width / 2) + offsetHor, Screen.height - pos.y - offset, width, 50), PlayerName, style);
            if (line2 != "")
            {
                string usingLine2 = "<" + line2 + ">";
                float width2 = usingLine2.Length * 10;
                GUI.Label(new Rect(pos.x - (width2 / 2) + offsetHor, Screen.height - pos.y - offset + 20, width2, 50), usingLine2, style);
            }
        }
    }
}