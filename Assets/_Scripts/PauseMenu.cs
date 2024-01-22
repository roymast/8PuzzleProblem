using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{    
    [SerializeField] GameManager gameManager;
    [SerializeField] SoundManager soundManager;
    [SerializeField] Image SFXGameObject;
    [SerializeField] Image MusicGameObject;

    [SerializeField] Sprite SFXOn;
    [SerializeField] Sprite SFXOff;
    [SerializeField] Sprite MusicOn;
    [SerializeField] Sprite MusicOff;

    bool isSFXActive;
    bool isMusicActive;
    
    public void ResumeGame()
    {

    }

    public void ToggleMusic()
    {
        isMusicActive = !isMusicActive;
        SetActiveMusic(isMusicActive);
    }
    public void ToggleSFX()
    {
        isSFXActive = !isSFXActive;
        SetActiveSFX(isSFXActive);
    }
    public void SetActiveMusic(bool isActive)
    {
        isMusicActive = isActive;
        PlayerPrefs.SetInt("IsMusicActive", (isActive) ? 1 : 0);
        soundManager.SetActiveMusic(isActive);
        UpdateUI();
    }
    public void SetActiveSFX(bool isActive)
    {
        isSFXActive = isActive;
        PlayerPrefs.SetInt("IsSFXActive", (isActive) ? 1 : 0);
        soundManager.SetActiveSFX(isActive);
        UpdateUI();
    }

    void UpdateUI()
    {
        SFXGameObject.sprite = isSFXActive ? SFXOn : SFXOff;
        MusicGameObject.sprite = isMusicActive ? MusicOn : MusicOff;
    }

    // Start is called before the first frame update
    void Start()
    {
        isSFXActive = PlayerPrefs.GetInt("IsSFXActive") == 1 ? true : false;
        isMusicActive = PlayerPrefs.GetInt("IsMusicActive") == 1 ? true : false;
        SetActiveMusic(isMusicActive);
        SetActiveSFX(isSFXActive);
    }
}
