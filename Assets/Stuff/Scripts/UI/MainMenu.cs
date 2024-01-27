using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //Main Menu Variables
    public GameObject mainMenu;
    public GameObject levelSelectMenu;
    public GameObject settingsMenu;

    //Level Select Variables



    //Settings Variables
    public AudioMixer mainMixer;
    public Slider vol_Slider;
    public Toggle fullScreenToggle;


    void Start()
    {
        mainMixer.SetFloat("MasterVol", -6f);
    }

    void Update()
    {

    }

    #region Main Menu Functions

    public void OpenLevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("Quit Game");
    }

    public void ReturnToMainMenu(GameObject currentMenu)
    {
        currentMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    #endregion

    #region Level Select Functions

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void TurnRTXOn()
    {

    }

    #endregion

    #region Settings Functions

    public void AdjustVolume(float sliderVal)
    {
        mainMixer.SetFloat("MasterVol", Mathf.Log10(sliderVal) * 20);
    }

    public void SetFullscreen(bool fullscreen)
    {
        if (fullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

            Debug.Log("Set to Fullscreen");
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;

            Debug.Log("Set to Windowed");
        }
    }

    #endregion
}
