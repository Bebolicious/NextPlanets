using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTulic : Collidable
{
    public string[] message;
    private float cooldown = 4.0f;
    private float lastShout = -4.0f;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == false && GameManager.instance.fireFlowers < 10)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
        else if(Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == false && GameManager.instance.fireFlowers >= 10)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            GameManager.instance.fireFlowers -= 10;
            GameManager.instance.flowerQuest = true;
        }
        else if(GameManager.instance.flowerQuest == true) 
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[2], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
