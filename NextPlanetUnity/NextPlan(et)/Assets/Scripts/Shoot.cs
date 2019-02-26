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


    private Vector3 lastPosition;
    private Vector2 movementDirection;
    private Vector2 saveDir;

    void Start()
    {
        lastPosition = GameManager.instance.player.transform.position;
    }

    void Update()
    {
        movementDirection = (GameManager.instance.player.transform.position - lastPosition).normalized;
        if (movementDirection.magnitude >= 1)
        {
            saveDir = movementDirection;
        }
        lastPosition = GameManager.instance.player.transform.position;
        if (GameManager.instance.hasWeapon == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shooting");
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,
                beamSpawn.position, beamSpawn.rotation) as Rigidbody2D;

            instantiatedProjectile.AddForce(saveDir * speed);
        }
    }

    void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }

            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);

        }
    }
}
