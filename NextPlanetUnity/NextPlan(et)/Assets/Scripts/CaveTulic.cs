using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTulic : Collidable
{
    public string[] message;
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
        if (Time.time - lastShout > cooldown && GameManager.instance.caveQuest == false && GameManager.instance.savedTulics < 5)
        {
            GameManager.instance.hasWeapon = true;
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.blue, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
        else if (Time.time - lastShout > cooldown && GameManager.instance.caveQuest == false && GameManager.instance.savedTulics >= 5)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.green, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            GameManager.instance.caveQuest = true;
            GameManager.instance.savedTulics = 0;
        }
        else
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[2], 25, Color.green, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
