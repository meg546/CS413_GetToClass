using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneButtons : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Basemap");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
