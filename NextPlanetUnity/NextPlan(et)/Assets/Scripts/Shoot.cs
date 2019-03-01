using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform beamSpawn;

    public float speed = 200;
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    private float cooldown = 0.5f;
    private float lastShot;


    private Vector3 lastPosition;
    private Vector2 movementDirection;
    private Vector2 saveDir;

    void Start()
    {
        lastPosition = GameManager.instance.player.transform.position;
    }

    void Update()
    {
        if (GameManager.instance.hasAutoLaser == true)
        {
            cooldown = 0.0f;
        }

        movementDirection = (GameManager.instance.player.transform.position - lastPosition).normalized;
        if (movementDirection.magnitude >= 1)
        {
            saveDir = movementDirection;
        }
        lastPosition = GameManager.instance.player.transform.position;
        if (GameManager.instance.hasWeapon == true && Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShot > cooldown)
            {
                lastShot = Time.time;
                Rigidbody2D instantiatedProjectile = Instantiate(projectile,
                    beamSpawn.position, beamSpawn.rotation) as Rigidbody2D;

                instantiatedProjectile.AddForce(saveDir * speed);
                Debug.Log(saveDir.ToString());
            }
        }
    }

}
