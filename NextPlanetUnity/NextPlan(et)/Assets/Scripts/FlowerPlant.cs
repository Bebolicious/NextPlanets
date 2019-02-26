using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlant : Collectable
{
    public Sprite EmptyFlower;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = EmptyFlower;
            GameManager.instance.fireFlowers++;
            GameManager.instance.ShowText("+1 Fire Flower!", 25, Color.magenta, transform.position, Vector3.up * 25, 1.0f);

        }

    }
}
