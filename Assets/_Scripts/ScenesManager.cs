using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public void GoToHome()
    {
        Debug.Log("Home");
        SceneManager.LoadScene("Home");
    }
    public void GoToStore()
    {
        SceneManager.LoadScene("Store");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
