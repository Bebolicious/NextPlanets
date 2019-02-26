using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTulic : Collectable
{

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Destroy(gameObject);
            GameManager.instance.savedTulics++;
            GameManager.instance.ShowText("You have saved " + GameManager.instance.savedTulics + " tulics!", 25, Color.green, transform.position, Vector3.up * 25, 1.0f);

        }

    }
}
