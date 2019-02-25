using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExScript : Collidable
{
    public string[] message;  // The NPC's message, he will shout it on contact, change in the inspector
    private float cooldown = 4.0f;
    private float lastShout;
    private bool extinguish;
    public GameObject FireOne;
    public GameObject FireTwo;
    public GameObject FireEx;

    // Overrides
    protected override void Start()
    {       
        base.Start();
        lastShout = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastShout > cooldown)
        {            
            lastShout = Time.time;
            GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
           
        } else if (Time.time - lastShout > cooldown)
        {           
            lastShout = Time.time;
            GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.32f, 0), Vector3.zero, cooldown);
        }

    }
    protected void OnCollisionEnter(Collision whoops)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("test");
            FireOne.SetActive(false);
            FireTwo.SetActive(false);
            FireEx.SetActive(true);
            extinguish = true;
        }       
    }
}
