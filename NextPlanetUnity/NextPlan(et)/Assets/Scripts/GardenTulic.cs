using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTulic : Collidable
{
    public string[] message;
    private float cooldown = 4.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("Colliding");
        if (Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == false && GameManager.instance.fireFlowers < 10)
        {
            Debug.Log("Colliding 1");

            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
        else if(Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == false && GameManager.instance.fireFlowers >= 10)
        {
            Debug.Log("Colliding 2");

            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            GameManager.instance.fireFlowers -= 10;
            GameManager.instance.flowerQuest = true;
        }
        else if(GameManager.instance.flowerQuest == true) 
        {
            Debug.Log("Colliding 3");

            lastShout = Time.time;
            GameManager.instance.ShowText(message[2], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
