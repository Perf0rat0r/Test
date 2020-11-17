using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger2 : MonoBehaviour
{
        
        private Animator doorAnimator;
        
        [SerializeField]    
        private GameObject doorOpenButton;
        [SerializeField]
        private GameObject door;

        
  
    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }
                
        
    void OnTriggerEnter(Collider Player)
    {
        doorOpenButton.GetComponent<Button>().onClick.AddListener(openDoor2);
        doorOpenButton.SetActive(true);
    }
    void OnTriggerExit(Collider Player)
    {
        doorOpenButton.SetActive(false);
        doorAnimator.SetBool("isDoorOpen",false);
        doorOpenButton.GetComponent<Button>().onClick.RemoveListener(openDoor2);
    }

        void openDoor2()
        {
                if (!doorAnimator.GetBool("isDoorOpen2"))
                {
                    doorAnimator.SetBool("isDoorOpen2",true);
                }
                else
                {
                   doorAnimator.SetBool("isDoorOpen2",false); 
                   
                }
        }
        
}
