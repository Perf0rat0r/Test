using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   private bool optionMenuIsOpen = false;
   private bool newsMenuIsOpen = false;
   private bool settingsMenuIsOpen = false;
   private bool playMenuIsOpen = false;

   public Animator mainMenuAllAnimController;
   public Animator playMenuAllAnimController;
   public Animator settingsMenuAnimController;
   public Animator newsAnimController;
   public Animator cameraAnimController;
   public Animator joinUsAnimController;
   public Animator thirdPanelAnimController;
   public Animator testSceneAnimController;
   public Animator episode1AnimController;
   
   public GameObject blur;

   void Start()
   {
      blur.SetActive(false);
   }
    public void PlayMenu ()
 {
         if (playMenuIsOpen == false)
     {
        cameraAnimController.SetTrigger("isCameraCalledToPlay");
        mainMenuAllAnimController.SetTrigger("isMainMenuAllFaded");
        playMenuAllAnimController.SetTrigger("isPlayMenuCalled");
        playMenuIsOpen = true;
     }
     else
     {
        cameraAnimController.SetTrigger("isCameraCalledToMainMenu");
        mainMenuAllAnimController.SetTrigger("isMainMenuAllUnfaded");
        playMenuAllAnimController.SetTrigger("isPlayMenuClosed");
        playMenuIsOpen = false;
     }
 }
    public void ExitGame ()
 {
        Application.Quit();
 }

 
   public void NewsMenu()
   {
      if (newsMenuIsOpen == false)
     {
        newsAnimController.SetTrigger("isNewsMenuOpen");
        joinUsAnimController.SetTrigger("isPanelHidden");
        thirdPanelAnimController.SetTrigger("isPanelHidden");
        newsMenuIsOpen = true;
        blur.SetActive(true);
     }
     else
     {
        newsAnimController.SetTrigger("isNewsMenuClosed");
        joinUsAnimController.SetTrigger("isPanelUnhidden");
        thirdPanelAnimController.SetTrigger("isPanelUnhidden");
        newsMenuIsOpen = false;
        blur.SetActive(false);
     }
   }
   public void SettingsMenu()
   {
       if (settingsMenuIsOpen == false)
     {
        cameraAnimController.SetTrigger("isCameraCalledToSettings");
        mainMenuAllAnimController.SetTrigger("isMainMenuAllFaded");
        settingsMenuAnimController.SetTrigger("isSettingsMenuCalled");
        settingsMenuIsOpen = true;
     }
     else
     {
        cameraAnimController.SetTrigger("isCameraCalledToMainMenu");
        mainMenuAllAnimController.SetTrigger("isMainMenuAllUnfaded");
        settingsMenuAnimController.SetTrigger("isSettingsMenuClosed");
        settingsMenuIsOpen = false;
     }
   }
   public void GetDiscordUrl()
   {
      Application.OpenURL("https://discord.gg/r6qE7f7");
   
   }
   public void PlayEpisode1()
   {

   }
   public void PlayTestScene()
   {
      if (testSceneAnimController.GetCurrentAnimatorStateInfo(0).IsName("TestSceneIdle"))
      {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
      }
      
      
   }
   public void LeftSceneArrow()
   {
      if (testSceneAnimController.GetCurrentAnimatorStateInfo(0).IsName("TestScenePopDown"))
      {
      testSceneAnimController.SetTrigger("isLeftArrowPressed");
      episode1AnimController.SetTrigger("isLeftArrowPressed");
      }
   }
    public void RightSceneArrow()
   {
      if (testSceneAnimController.GetCurrentAnimatorStateInfo(0).IsName("TestSceneIdle"))
      {
      testSceneAnimController.SetTrigger("isRightArrowPressed");
      episode1AnimController.SetTrigger("isRightArrowPressed"); 
      }
   }
   
}
