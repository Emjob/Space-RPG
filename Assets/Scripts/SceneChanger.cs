using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private BattleManager BattleManager;

    void Start()
    {
        
        BattleManager = GetComponent<BattleManager>();
        DontDestroyOnLoad(gameObject);
    }
     

     public void LoadScene(string MenuNavigation)
     {
        //BattleManager.BattleData.currentScreen = BattleManager.MapScreens[i];
        BattleManager.SaveGameStatus();
        SceneManager.LoadScene(MenuNavigation);
        
        
        
    }

    public void ChangeNumber(int id)
    {
        BattleManager.BattleData.currentScreen = id;
    }
}
