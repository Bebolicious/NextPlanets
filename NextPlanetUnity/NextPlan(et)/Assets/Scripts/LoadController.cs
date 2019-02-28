using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadController : MonoBehaviour
{
    public void LoadMainMenu(string scenname)
    {
        SceneManager.LoadScene(scenname);
    }
}
