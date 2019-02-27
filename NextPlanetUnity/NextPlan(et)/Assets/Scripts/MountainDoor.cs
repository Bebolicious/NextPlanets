using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainDoor : Collidable
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
        if (coll.name == "Player")
        {
            if (Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == false)
            {
                Debug.Log("Door1");
                lastShout = Time.time;
                GameManager.instance.ShowText(message[0], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
            }
            else if (Time.time - lastShout > cooldown && GameManager.instance.flowerQuest == true)
            {
                Debug.Log("Door2");
                lastShout = Time.time;
                GameManager.instance.ShowText(message[1], 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Basement");
            }

        }

    }
}
