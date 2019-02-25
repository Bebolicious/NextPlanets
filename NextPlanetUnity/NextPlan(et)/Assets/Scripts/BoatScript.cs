using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public GameObject BoatObject;
    public GameObject PlayerObject;
    // Start is called before the first frame update
    void Start()
    {
        BoatObject.GetComponent<Renderer>().enabled = false;
        PlayerObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
