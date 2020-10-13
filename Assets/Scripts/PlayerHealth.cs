using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int startingHealth = 100;

    public int currentHealth;  

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject pistol;

    public HealthBar healthBar; 

    Animator playerAnimator;
   
    void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        playerAnimator = GetComponent<Animator>();
    }

    public void TakeDamagePlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        

        if (currentHealth <= 0)
        {
            playerAnimator.SetBool("isDead", true);
            player.GetComponent<CharacterController>().enabled = false;
            pistol.GetComponent<Pistol>().enabled = false;
            
        }
    }
}
