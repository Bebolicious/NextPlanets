using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldDestroy : Collidable
{
    public GameObject forceField;
    public GameObject NotAGlassForcefield;
    public GameObject Kaboom;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Beam")
        {
            forceField.SetActive(false);
            NotAGlassForcefield.SetActive(false);
            Kaboom.SetActive(true);
        }
        
    }
}
