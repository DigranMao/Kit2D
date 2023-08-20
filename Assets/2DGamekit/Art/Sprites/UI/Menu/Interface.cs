using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Option()
    {
        Application.OpenURL("https://www.twitch.tv/digranmao");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
