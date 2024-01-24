using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tutorial : MonoBehaviour
{
    [SerializeField] ScenesManager scenesManager;
    [SerializeField] Canvas[] tutorialCanvases;
    int index;
    public static bool IsNeedTutorial()
    {
        return PlayerData.IsTutorialNeeded;
    }
    private void Start()
    {
        PlayerData.IsTutorialNeeded = false;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextPage();
        }
    }
    private void NextPage()
    {
        tutorialCanvases[index].gameObject.SetActive(false);
        index++;
        if (index == tutorialCanvases.Length)
            scenesManager.LoadLastScene();
        else
            tutorialCanvases[index].gameObject.SetActive(true);
    }    
}
