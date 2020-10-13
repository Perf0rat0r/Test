using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseMenu : MonoBehaviour
{
    public static bool gamepIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject blur;
   
   public void ResumeAndPause()
   {
       if (!gamepIsPaused)
       {
       pauseMenuUI.SetActive(true);
       blur.SetActive(true);
       Time.timeScale = 0;
       gamepIsPaused = true;
       }
       else
       { 
       pauseMenuUI.SetActive(false);
       blur.SetActive(false);
       Time.timeScale = 1;
       gamepIsPaused = false;
              
       }
   }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
