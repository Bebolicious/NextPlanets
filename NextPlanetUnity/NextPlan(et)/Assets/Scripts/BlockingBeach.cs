using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingBeach : MonoBehaviour
{
    public GameObject Blocking;

    void Update()
    {
        if (GameManager.instance.beachQuest == true)
        {
            Blocking.SetActive(true);
        }
    }
}
