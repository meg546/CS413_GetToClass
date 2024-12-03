using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void EasyLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MediumLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }


    public void HardLevel()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
