using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsMenu : MonoBehaviour
{
    private GameObject newsPanel;
    public ScrollRect myScrollRect;

    public Animator newsMenuAnimController;

    void Start()
    {
      ScrollRect newsMenu = GameObject.FindWithTag("newsPanel").GetComponent<UnityEngine.UI.ScrollRect>();
      newsMenu.enabled = false;
    }

  public void ScrollTurnOffAndOn()
  {
      if (newsMenuAnimController.GetCurrentAnimatorStateInfo(0).IsName("NewsMenuIdle"))
      {
           ScrollRect newsMenu = GameObject.FindWithTag("newsPanel").GetComponent<UnityEngine.UI.ScrollRect>();
           newsMenu.enabled = true;
      }
      else 
      {
          ScrollRect newsMenu = GameObject.FindWithTag("newsPanel").GetComponent<UnityEngine.UI.ScrollRect>();
           newsMenu.enabled = false;
           myScrollRect.verticalNormalizedPosition = 1;
      }
  }
}
