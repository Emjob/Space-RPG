using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class BattleData
{
    public int currentScreen;
}
public class BattleManager : MonoBehaviour
{
    public BattleData BattleData;
    //public BattleSettings BattleSettings;
    private SceneChanger SceneChanger;
    public List<GameObject> MapScreens;
    public string filePath;
    private const string FILE_NAME = "CurrentLevel.json";
    public GameObject currentScreenObj;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath;
        MapScreens = new List<GameObject>();
        SceneChanger = GameObject.Find("LevelSelector").GetComponent<SceneChanger>();
        foreach (GameObject Screen in GameObject.FindGameObjectsWithTag("MapScreen"))
        {
            MapScreens.Add(Screen);
            Screen.SetActive(false);
        }
        LoadGameStats();       
    }
    
    public void LoadGameStats()
    {
        if (File.Exists(filePath + "/" + FILE_NAME))
        {
            string currentLevel = File.ReadAllText(filePath + "/" + FILE_NAME);
            BattleData = JsonUtility.FromJson<BattleData>(currentLevel);
            currentScreenObj = MapScreens[BattleData.currentScreen];
            currentScreenObj.SetActive(true);
            Debug.Log("Game loaded successfully");
            
        }
        else
        {
            currentScreenObj = MapScreens[0];
            currentScreenObj.SetActive(true);
            Debug.Log("No file here.");
        }
    }
    
   public void SaveGameStatus()
    {
        string currentLevel = JsonUtility.ToJson(BattleData);
        File.WriteAllText(filePath + "/" + FILE_NAME, currentLevel);
        Debug.Log("Files saved");
    }

   private void OnApplicationQuit()
   {
       SaveGameStatus();
   }

   private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}

