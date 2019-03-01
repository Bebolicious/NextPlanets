using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeam : Collidable
{
    private float beamLifeTime = 3.0f;

    protected override void Update()
    {
        base.Update();
        beamLifeTime -= Time.deltaTime;

        if (beamLifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player")
        {

            Damage dmg = new Damage
            {
                damageAmount = 2,
                origin = transform.position,
                pushForce = 3
            };

            collision.collider.SendMessage("ReceiveDamage", dmg);
            Destroy(gameObject);
        }

    }

}
