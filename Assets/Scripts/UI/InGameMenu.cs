using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inGameMenuPanel;

    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private GameObject soundPanel;

    [SerializeField]
    private GameObject controlsPanel;

    [SerializeField]
    private GameObject retryPanel;

    [SerializeField]
    private GameObject victoryPanel;

    public bool isMenuOpen;

    public void OpenMenuPanel()
    {
        if (retryPanel.activeInHierarchy || victoryPanel.activeInHierarchy) return;

        SoundManager.instance.PlaySFX(1);

        GameManager.instance.Pause();

        isMenuOpen = true;

        inGameMenuPanel.SetActive(true);
    }

    public void OpenSettingsPanel()
    {
        SoundManager.instance.PlaySFX(1);

        settingsPanel.SetActive(true);
    }

    public void OpenSoundPanel()
    {
        SoundManager.instance.PlaySFX(1);

        soundPanel.SetActive(true);
    }

    public void OpenControlsPanel()
    {
        SoundManager.instance.PlaySFX(1);

        controlsPanel.SetActive(true);
    }

    public void OpenRetryPanel()
    {
        SoundManager.instance.PlaySFX(1);

        retryPanel.SetActive(true);
    }

    public void OpenVictoryPanel()
    {
        SoundManager.instance.PlaySFX(1);

        victoryPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        //SoundManager.instance.PlaySFX(2);

        GameManager.instance.UnPause();

        isMenuOpen = false;

        inGameMenuPanel.SetActive(false);
    }

    public void CloseActivePanel()
    {
        //SoundManager.instance.PlaySFX(2);

        if (soundPanel.activeInHierarchy) { soundPanel.SetActive(false); return; }
        if (controlsPanel.activeInHierarchy) { controlsPanel.SetActive(false); return; }
        if (settingsPanel.activeInHierarchy) { settingsPanel.SetActive(false); return; }
    }

    public void ResetGame()
    {
        if (inGameMenuPanel.activeInHierarchy) return;

        SoundManager.instance.PlaySFX(1);

        GameManager.instance.UnPause();

        GameManager.instance.LoadScene("Game");
    }

    public void LoadMenu()
    {
        SoundManager.instance.PlaySFX(1);

        GameManager.instance.UnPause();

        GameManager.instance.LoadScene("Menu");
    }
}
