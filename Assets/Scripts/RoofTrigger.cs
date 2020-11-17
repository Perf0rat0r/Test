using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject roof;

   
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        roof.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        roof.SetActive(false);
    }
}
