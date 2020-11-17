using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    public GameObject button;

    private bool flashLightOn = false;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(turnFlashLight);
    }

    void turnFlashLight()
    {
        if (!flashLightOn) 
        {
            flashLight.SetActive(true);
            flashLightOn = true;
        } 
        else 
        {
            flashLight.SetActive(false);
            flashLightOn = false;
        }
    }
}
