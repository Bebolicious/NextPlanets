﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Collidable
{
    private float beamLifeTime = 2.0f;

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
        if (collision.collider.tag == "Fighter" || collision.collider.tag == "Boss")
        {

            Damage dmg = new Damage
            {
                damageAmount = 1,
                origin = transform.position,
                pushForce = 2
            };

            collision.collider.SendMessage("ReceiveDamage", dmg);
            Destroy(gameObject);
        }
        
    }

}
