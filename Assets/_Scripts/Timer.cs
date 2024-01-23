using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI displayTimer;
    float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    public float GetTime()
    {
        return (int)(Time.time - startTime);
    }
    // Update is called once per frame
    void Update()
    {
        if(!gameManager.IsGameEnd) 
            displayTimer.text = "Time: "+((int)(Time.time - startTime)).ToString();
    }
}
