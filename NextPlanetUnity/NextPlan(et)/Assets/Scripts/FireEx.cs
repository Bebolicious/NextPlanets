using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEx : MonoBehaviour
{
    public GameObject FireExSystem;
    public GameObject FireOne;
    public GameObject FireTwo;


    int x = 1;
    int y = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x < y) // If player collides with fireEx
        {           
            FireExSystem.SetActive(true);
            FireOne.SetActive(false);
            FireTwo.SetActive(false);
        }

    }
}
