using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Color newColor;
    public Color standartColor;

    private int qualityLevel = 2;

    void Start ()
    {
       ColorBlock cb3 = button3.colors;
      cb3.normalColor = newColor;
      button3.colors = cb3; 
    }
    void Update ()
    {
       if (qualityLevel == 0)
       {
           Button1Collor();
       }
       if (qualityLevel == 1)
       {
           Button2Collor();
       }
       if (qualityLevel == 2)
       {
           Button3Collor();
       }
    }
   
   public void SetQualityLow ()
   {
      QualitySettings.SetQualityLevel(0);
      qualityLevel = 0;
     
   }
   public void SetQualityMedium ()
   {
      QualitySettings.SetQualityLevel(1);
      qualityLevel = 1;
      
   }
   public void SetQualityHigh ()
   {
      QualitySettings.SetQualityLevel(2);
      qualityLevel = 2;
   
   }
   void Button1Collor()
   {
         ColorBlock cb1 = button1.colors;
         cb1.normalColor = newColor;
         button1.colors = cb1;

         ColorBlock cb2 = button2.colors;
         cb2.normalColor = standartColor;
         button2.colors = cb2;

         ColorBlock cb3 = button3.colors;
         cb3.normalColor = standartColor;
         button3.colors = cb3;
         
   }

   void Button2Collor()
   {
         ColorBlock cb2 = button2.colors;
         cb2.normalColor = newColor;
         button2.colors = cb2; 

         ColorBlock cb1 = button1.colors;
         cb1.normalColor = standartColor;
         button1.colors = cb1; 

         ColorBlock cb3 = button3.colors;
         cb3.normalColor = standartColor;
         button3.colors = cb3;
         
   }

   void Button3Collor()
   {
         ColorBlock cb3 = button3.colors;
         cb3.normalColor = newColor;
         button3.colors = cb3; 

         ColorBlock cb1 = button1.colors;
         cb1.normalColor = standartColor;
         button1.colors = cb1; 

         ColorBlock cb2 = button2.colors;
         cb2.normalColor = standartColor;
         button2.colors = cb2; 
   }
}
