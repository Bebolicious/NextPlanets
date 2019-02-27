using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraterQuestDone : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.instance.craterQuest = true;
        }
    }
}
