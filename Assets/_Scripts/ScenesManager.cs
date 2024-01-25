using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public static string LastScene = "";
    static int screenshotIndex = 0;
    private void Start()
    {
        if(LastScene == string.Empty)
            LastScene = "Home";
    }
    public void LoadLastScene()
    {
        string tempLastScene = LastScene;
        LastScene = tempLastScene;
        SceneManager.LoadScene(tempLastScene);
    }
    public void GoToHome()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Home");
    }
    public void GoToStore()
    {
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Store");
    }
    public void StartGame()
    {
        if (PlayerData.IsTutorialNeeded)
        {
            LastScene = "Game";
            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            LastScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Game");
        }
    }
    public void StartTutorial()
    {   
        LastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Tutorial");        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ScreenCapture.CaptureScreenshot($"Assets/ScreenShots/screen{screenshotIndex}.png");
                screenshotIndex++;
            }
        }
    }
}
