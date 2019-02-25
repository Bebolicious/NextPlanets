using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTulic : Collidable
{
    public string[] message;
    private bool flowerQuest = false;
    private float cooldown = 4.0f;
    private float lastShout;

    // Overrides
    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown && flowerQuest == false && GameManager.instance.flowerPlants < 10)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
        else if(Time.time - lastShout > cooldown && flowerQuest == false && GameManager.instance.flowerPlants >= 10)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            GameManager.instance.flowerPlants -= 10;
            flowerQuest = true;
        }
        else
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[2], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
