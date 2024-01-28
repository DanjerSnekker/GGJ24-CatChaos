using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    //Target Variables
    public List<Target> targets;

    public TMP_Text targetCounter;
    public int targetCount;

    //Variable that stores the win animation.

    public GameObject winScreen;

    //Variable that stores the lose animation.

    public GameObject loseScreen;

    //Timer Variables
    public float timerDuration;
    public TMP_Text timerText;
    public bool timerActive;

    //Pause Variables   -   Might need to move to itsown script
    public GameObject pauseMenu;
    public Slider volSlider;


    void Start()
    {
        targets = new List<Target>();

        targetCounter.text = "0/" + targetCount;
        timerText.text = timerDuration.ToString();
    }

    void Update()
    {
        /*if (!timerActive)
        {
            return;
        }*/

    }

    private void FixedUpdate()
    {
        if (timerActive)
        {
            StartTimer();
        }
    }

    #region Game Functions

    public void PlaySequence()
    {
        if (targets.Count == targetCount)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        timerActive = false;
        //Play the corresponding animation

        //After the animation is done playing, enable the WIN Screen.
        winScreen.SetActive(true);
    }

    public void LoseGame()
    {
        timerActive = false;
        //Play the corresponding animation

        //After the animation is done playing, enable the LOSE Screen.
        loseScreen.SetActive(true);
    }

    public void LoadNewsScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void UpdateTargetCounter()
    {
        targetCounter.text = targets.Count.ToString() + "/" + targetCount;
    }

    #endregion

    #region Timer Functions

    public void StartTimer()
    {
        if (timerDuration > 0)
        {
            timerDuration -= Time.deltaTime;
            UpdateTimerText(timerDuration);
            //Play a sfx clip that repeats itself after each second.

        }
        else
        {
            Debug.Log("Time is up");

            timerDuration = 0;
            timerActive = false;
            LoseGame();
        }
    }

    public void UpdateTimerText(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = seconds.ToString();
    }

    #endregion

    #region Pause Menu Functions  -   Might need to move to its own script
    public void PauseGame()
    {
        timerActive = false;

        pauseMenu.SetActive(true);

        //[If players are able to interact with objects when paused, add code to disable their specific components from doing so here.]
    }

    public void ResumeGame()
    {
        timerActive = true;

        pauseMenu.SetActive(false);

        //[If players are able to interact with objects when paused, add code to enable their specific components from doing so here.]
    }

    public void ReturnToMenu(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Reloading Level");
        //Reload the current scene.
    }

    public void AdjustVolume()
    {
        //Adjust the volume of the game using the slider.
    }
    #endregion


}
