using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExScripy : Collidable
{
    public GameObject FireOne;
    public GameObject FireTwo;
    public GameObject Ex;
    public GameObject Boat;
    // Start is called before the first frame update

    // Update is called once per frame
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player" && GameManager.instance.beachQuest == false)
        {
            FireOne.SetActive(false);
            FireTwo.SetActive(false);
            Ex.SetActive(true);
            Boat.SetActive(true);
            GameManager.instance.beachQuest = true;
        }
    }
    

}
