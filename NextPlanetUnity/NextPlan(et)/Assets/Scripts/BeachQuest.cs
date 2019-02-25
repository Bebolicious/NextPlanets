﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachQuest : Collidable
{
    public string[] message;  // The NPC's message, he will shout it on contact, change in the inspector
    private float cooldown = 4.0f;
    private float lastShout;
    private bool questDone = false;

    // Overrides
    protected override void Start()
    {

        base.Start();
        lastShout = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown && questDone == false)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
        }
            if (Time.time - lastShout > cooldown && questDone == true)
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
        }
        
    }
}
