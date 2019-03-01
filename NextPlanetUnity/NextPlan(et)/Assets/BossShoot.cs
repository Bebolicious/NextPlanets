using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform launcherOne;
    public Transform launcherTwo;
    private Vector2 projectileDirectionOne;
    private Vector2 projectileDirectionTwo;


    public float speed = 100;
    public int damagePoint = 1;
    public float pushForce = 2.0f;
    private float cooldownOne = 0.5f;
    private float cooldownTwo = 0.5f;
    private float lastShotOne;
    private float lastShotTwo;

    void Update()
    {
        projectileDirectionOne = (-launcherOne.transform.position);
        projectileDirectionTwo = (-launcherTwo.transform.position);
        if (Time.time - lastShotOne > cooldownOne)
        {
            lastShotOne = Time.time;
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,
                launcherOne.position, launcherOne.rotation) as Rigidbody2D;

            instantiatedProjectile.AddForce(projectileDirectionOne * speed);
        }

        if (Time.time - lastShotTwo > cooldownTwo)
        {
            lastShotTwo = Time.time;
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,
                launcherTwo.position, launcherTwo.rotation) as Rigidbody2D;

            instantiatedProjectile.AddForce(projectileDirectionTwo * speed);
        }

    }
}
