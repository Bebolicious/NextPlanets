using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAstronaut : Collidable
{
    public string message;
    private float cooldown = 4.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (GameManager.instance.hasAutoLaser == false && coll.name == "Player")
        {
            GameManager.instance.hasAutoLaser = true;
            GameManager.instance.ShowText(message, 25, Color.green, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
    }
}
