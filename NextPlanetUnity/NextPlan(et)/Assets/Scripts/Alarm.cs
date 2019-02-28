using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{

    public AudioSource Aso;

    // Start is called before the first frame update
    void Start()
    {
        Aso = GetComponent<AudioSource>();
        Debug.Log("Jag e på");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hej");
        if (collision.collider.name == "Player")
        {
            Aso.Play();
            Debug.Log("hej");
        }
        Debug.Log("hej");
    }

}
