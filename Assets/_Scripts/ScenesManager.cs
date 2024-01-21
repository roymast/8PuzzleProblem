using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public void GoToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}