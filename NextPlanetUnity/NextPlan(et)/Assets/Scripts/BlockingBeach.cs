using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingBeach : MonoBehaviour
{
    public GameObject BlockingBeachQuest;
    public GameObject BlockingCraterQuest;
    public GameObject BlockingLastScene;


    void Update()
    {
        if (GameManager.instance.beachQuest == true)
        {
            BlockingBeachQuest.SetActive(true);
        }

        if (GameManager.instance.craterQuest == true)
        {
            BlockingCraterQuest.SetActive(true);

        }

        if (GameManager.instance.flowerQuest == false)
        {
            BlockingLastScene.SetActive(true);
        }

    }
}
