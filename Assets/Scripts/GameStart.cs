using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameLoop");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
