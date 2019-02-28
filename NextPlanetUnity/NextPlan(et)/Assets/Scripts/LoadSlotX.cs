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
    private const string conString = "Server=tcp:academyunity.database.windows.net,1433;Initial Catalog=mysqlserver;Persist Security Info=False;User ID=AcademyAdmin;Password=pOWERkING!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

    public void getDataBaseInput(int id)
    {
        if (id == 0 && isDataBaseChecked == false)
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
        if (isDataBaseChecked == false)
        {
            var sql = @"select * from SaveData where id = " + id.ToString();
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command2 = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    RawData = reader.GetSqlString(1).ToString();
                }

            }
            string[] data = RawData.Split('|');
            GameManager.instance.credits = int.Parse(data[0]);
            GameManager.instance.fireFlowers = int.Parse(data[1]);
            GameManager.instance.savedTulics = int.Parse(data[2]);
            GameManager.instance.experience = int.Parse(data[3]);
            GameManager.instance.ScenName = data[4];
            if (int.Parse(data[5]) == 0)
            {
                GameManager.instance.flowerQuest = false;
            }
            else
            {
                GameManager.instance.flowerQuest = true;
            }
            if (int.Parse(data[6]) == 0)
            {
                GameManager.instance.caveQuest = false;
            }
            else
            {
                GameManager.instance.caveQuest = true;
            }
            if (int.Parse(data[7]) == 0)
            {
                GameManager.instance.hasWeapon = false;
            }
            else
            {
                GameManager.instance.hasWeapon = true;
            }
            if (int.Parse(data[8]) == 0)
            {
                GameManager.instance.beachQuest = false;
            }
            else
            {
                GameManager.instance.beachQuest = true;
            }
            if (int.Parse(data[9]) == 0)
            {
                GameManager.instance.craterQuest = false;
            }
            else
            {
                GameManager.instance.craterQuest = true;
            }
            GameManager.instance.SaveSlot = int.Parse(data[10]);
            isDataBaseChecked = true;
            SceneManager.LoadScene(data[4]);
        }

    }
}
