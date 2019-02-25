using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlayer : MonoBehaviour
{

    public GameObject PlayerObject;
    public GameObject BoatObject;
    void Start()
    {
        PlayerObject.GetComponent<Renderer>().enabled = true;

        BoatObject.GetComponent<Renderer>().enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
