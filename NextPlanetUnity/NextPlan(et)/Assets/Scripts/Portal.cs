using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Collidable
{
    public string[] sceneNames;

    // Override
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            // Teleport the player
            
            string sceneName = sceneNames[0];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
