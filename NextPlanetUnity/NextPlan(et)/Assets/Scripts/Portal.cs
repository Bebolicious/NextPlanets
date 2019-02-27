using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    private const string conString = "Server=tcp:academyunity.database.windows.net,1433;Initial Catalog=mysqlserver;Persist Security Info=False;User ID=AcademyAdmin;Password=pOWERkING!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            string s = "";
            string sceneName = sceneNames[0];            
            s += GameManager.instance.credits.ToString() + "|";
            s += GameManager.instance.fireFlowers.ToString() + "|";
            s += GameManager.instance.savedTulics.ToString() + "|";
            s += GameManager.instance.experience.ToString() + "|";
            s += sceneName + "|";
            if (GameManager.instance.flowerQuest == false)
            {
                s += 0.ToString() + "|";
            }
            else
            {
                s += 1.ToString() + "|";
            }
            if (GameManager.instance.caveQuest == false)
            {
                s += 0.ToString() + "|";
            }
            else
            {
                s += 1.ToString() + "|";
            }
            if (GameManager.instance.hasWeapon == false)
            {
                s += 0.ToString();
            }
            else
            {
                s += 1.ToString();
            }
            var sql = "UPDATE SaveData SET RawData = @s where id = 1";
            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("@s", s));
                command.ExecuteNonQuery();
            }

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

        }
    }
}
