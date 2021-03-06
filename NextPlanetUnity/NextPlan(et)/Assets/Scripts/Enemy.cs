﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Mover
{
    // Experience
    public int xpValue = 1;

    // Logic
    public float triggerLength = 1;
    public float chaseLength = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;
    public Animator animator2;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        if (gameObject.tag != "Boss")
        {
            // Is the player in range?
            if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
            {
                if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                    chasing = true;
                float hSpeed = 0.75f;
                animator2.SetFloat("SpeedH", Mathf.Abs(hSpeed));

                if (chasing)
                {
                    if (!collidingWithPlayer)
                    {
                        UpdateMotor((playerTransform.position - transform.position).normalized);
                    }
                }
                else
                {
                    UpdateMotor(startingPosition - transform.position);
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);
                chasing = false;
                float hSpeed = 0f;
                animator2.SetFloat("SpeedH", Mathf.Abs(hSpeed));

            }

        }

        // Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            //The array is not cleaned up, so we do it ourselves
            hits[i] = null;
        }

        UpdateMotor(Vector3.zero);
    }

    protected override void Death()
    {
        if (gameObject.name == "RobotBoss")
        {
            SceneManager.LoadScene("ThanksForPlaying");
        }
        else
        {
            Destroy(gameObject);
            GameManager.instance.GrantXp(xpValue);
            GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
        }
    }
}
