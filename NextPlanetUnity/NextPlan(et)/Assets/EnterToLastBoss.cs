using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToLastBoss : Collidable
{
    public GameObject OkData;
    public GameObject NotOkData;

    public string[] message;  // The NPC's message, he will shout it on contact, change in the inspector
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
        if (Time.time - lastShout > cooldown && GameManager.instance.hasKeyCard == false && coll.name == "Player")
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
        }
        if (Time.time - lastShout > cooldown && GameManager.instance.hasKeyCard == true && coll.name == "Player")
        {
            OkData.SetActive(true);
            NotOkData.SetActive(false);
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
            
        }
        
    }
}
