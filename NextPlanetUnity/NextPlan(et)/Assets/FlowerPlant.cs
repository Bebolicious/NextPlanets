using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlant : Collectable
{
    public Sprite emptyChest;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Destroy(gameObject);
            GameManager.instance.flowerPlants++;
            GameManager.instance.ShowText("+1 FlowerPlant!", 25, Color.magenta, transform.position, Vector3.up * 25, 1.0f);

        }

    }
}
