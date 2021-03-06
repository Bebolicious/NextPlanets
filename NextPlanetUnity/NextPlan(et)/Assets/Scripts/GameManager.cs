﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            //Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;


    }


    // Resources
    public List<Sprite> playerSprites;
    public List<int> xpTable;

    // References
    public Player player;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitPointBar;
    public CanvasGroup canvasGroup;



    public Animator deathMenuAnim;
    public GameObject hud;
    public GameObject menu;

    // Logic
    
    public int SaveSlot;
    public string ScenName;
    private string currentScene;
    public int fireFlowers;
    public int savedTulics;
    public int experience;
    public int credits;
    public bool hasWeapon;
    public bool hasAutoLaser;
    public bool beachQuest;
    public bool craterQuest;
    public bool flowerQuest;
    public bool caveQuest;
    public bool bossQuest;
    public bool lastQuest;
    public bool hasKeyCard;
    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Hitpoint Bar
    public void OnHitpointChange()
    {
        float ratio = (float)player.hitPoint / (float)player.maxHitpoint;
        hitPointBar.localScale = new Vector3(1, ratio, 1);
    }

    //Experience System
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while (experience >= add)
        {
            add += xpTable[r];
            r++;

            if (r == xpTable.Count) // Max Level
                return r;
        }

        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;
    }
    public void GrantXp(int xp)
    {
        int currentLevel = GetCurrentLevel();
        experience += xp;
        if (currentLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }
    public void OnLevelUp()
    {
        Debug.Log("LEVEL UP!");
        player.OnLevelUp();
        OnHitpointChange();
    }

    // On Scene Loaded
    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
        currentScene = s.name.ToString();
    }

    // Death Menu and Respawn
    public void Respawn()
    {
        deathMenuAnim.SetTrigger("Hide");
        SceneManager.LoadScene(currentScene);
        player.Respawn();
    }


    // Save state   
    // * INT credits
    // * INT fireFlowers
    // * INT savedTulics
    // * INT experience
    // * String SceneName
    //  public bool flowerQuest = false;
    //public bool caveQuest = false;
    //public bool hasWeapon = false;
    //public bool beachQuest = false;


    public void SaveState()
    {

    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (s.name.ToString() == "MainMenu" || s.name.ToString() == "LoadSave" || s.name.ToString() == "Controllers")
        {
            canvasGroup.alpha = 0f;
        }
        else if (s.name.ToString() != "MainMenu" || s.name.ToString() != "LoadSave" || s.name.ToString() != "Controllers")
        {
            canvasGroup.alpha = 1f;
        }

    }

}
