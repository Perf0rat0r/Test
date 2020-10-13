using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{   
    public Pistol pS;
    private Rigidbody myBody;
    public float moveForce = 5f;

    public FixedJoystick joystick;
    Animator animator;

    
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        myBody.velocity = new Vector3(joystick.Horizontal * moveForce, myBody.velocity.y, joystick.Vertical * moveForce);
        
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        { 
            animator.SetBool("isMoving", true);
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
        }
        else 
        {
            animator.SetBool("isMoving", false);
        } 
        if (pS.shootIsExecuted && !animator.GetCurrentAnimatorStateInfo(0).IsName("Shooting"))
        {
            animator.SetTrigger("isShooting");
        }
        
    }
}

