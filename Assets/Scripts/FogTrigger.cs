using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject fog;
    private Animation fogFade;
    
    void Start()
    {
        fogFade = fog.GetComponent<Animation>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        fogFade.Play("FogFade");
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        Destroy(fog);
    }
}
