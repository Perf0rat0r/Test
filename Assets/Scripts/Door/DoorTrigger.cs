using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
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
        doorOpenButton.GetComponent<Button>().onClick.AddListener(openDoor);
        doorOpenButton.SetActive(true);
    }

    void OnTriggerExit(Collider Player)
    {
        doorOpenButton.SetActive(false);
        doorAnimator.SetBool("isDoorOpen2",false);
        doorOpenButton.GetComponent<Button>().onClick.RemoveListener(openDoor);
    }

        void openDoor()
        {
                if (!doorAnimator.GetBool("isDoorOpen"))
        {
                doorAnimator.SetBool("isDoorOpen",true);
                
        }
        else
        {
                doorAnimator.SetBool("isDoorOpen",false); 
                
        }

        }
        
}
