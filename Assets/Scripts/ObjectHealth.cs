using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 100;

    private int currentHealth;


    
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        

        if (currentHealth <= 0)
        {
            Die();
            
        }

    }
    
    
    
    private void Die()
    {
       gameObject.SetActive(false);
        
    }
    
}
