using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScriptForCraterQuest : Collidable
{
    public GameObject FireOne;

    // Start is called before the first frame update

    // Update is called once per frame
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            FireOne.SetActive(true);           
        }
    }
}
