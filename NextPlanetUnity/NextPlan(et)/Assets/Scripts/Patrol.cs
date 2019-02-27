using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    public Transform[] MoveSpots;
    private int Ranspot;
    public float startWaitTime;
    private float waitTime;

    private void Start()
    {
        Ranspot = Random.Range(0, MoveSpots.Length);

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveSpots[Ranspot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, MoveSpots[Ranspot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                Ranspot = Random.Range(0, MoveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}
