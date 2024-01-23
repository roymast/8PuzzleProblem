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

    public void ToggleMusic()
    {
        PlayerData.MusicActive = !PlayerData.MusicActive;        
        SetActiveMusic(PlayerData.MusicActive);
    }
    public void ToggleSFX()
    {
        PlayerData.SFXActive = !PlayerData.SFXActive;        
        SetActiveSFX(PlayerData.SFXActive);
    }
    public void SetActiveMusic(bool isActive)
    {
        PlayerData.MusicActive = isActive;                
        soundManager.SetActiveMusic(isActive);
        UpdateUI();
    }
    public void SetActiveSFX(bool isActive)
    {
        PlayerData.SFXActive = isActive;                
        soundManager.SetActiveSFX(isActive);
        UpdateUI();
    }

    void UpdateUI()
    {
        SFXGameObject.sprite = PlayerData.SFXActive ? SFXOn : SFXOff;
        MusicGameObject.sprite = PlayerData.MusicActive ? MusicOn : MusicOff;
    }

    // Start is called before the first frame update
    void Start()
    {        
        SetActiveMusic(PlayerData.MusicActive);
        SetActiveSFX(PlayerData.SFXActive);
    }
}
