using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSlotX : MonoBehaviour
{
    
    bool isDataBaseChecked;
    string RawData = "";

    public void getDataBaseInput(int id)
    {
        if (id != 5 && isDataBaseChecked == false)
        {
            GameManager.instance.credits = 0;
            GameManager.instance.fireFlowers = 0;
            GameManager.instance.savedTulics = 0;
            GameManager.instance.experience = 0;
            GameManager.instance.ScenName = "SpaceShip";
            GameManager.instance.flowerQuest = false;
            GameManager.instance.caveQuest = false;
            GameManager.instance.hasWeapon = false;
            GameManager.instance.beachQuest = false;
            GameManager.instance.craterQuest = false;
            GameManager.instance.SaveSlot = id;
            isDataBaseChecked = true;
            SceneManager.LoadScene("SpaceShip");

        }
       

    }
}
