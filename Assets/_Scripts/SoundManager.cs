using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioSource MusicAudioSource;

    private void Start()
    {
        GridTileSwitcher.OnSwitchSucceeded += OnSwitchTiles;
    }
    private void OnDestroy()
    {
        GridTileSwitcher.OnSwitchSucceeded -= OnSwitchTiles;
    }
    public void OnSwitchTiles()
    {        
        if(SFXAudioSource.gameObject.activeInHierarchy)
            SFXAudioSource.Play();
    }    
    public void SetActiveSFX(bool isActive)
    {
        SFXAudioSource.gameObject.SetActive(isActive);
    }    
    public void SetActiveMusic(bool isActive)
    {
        MusicAudioSource.gameObject.SetActive(isActive);                
    }
}
