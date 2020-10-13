using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 100;

    private int currentHealth;

    Animator zombieAnimator;

    [SerializeField]
    private GameObject zombie;

    
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

      void Start ()
    {
        if (gameObject.tag == "Zombie") {
        zombieAnimator = GetComponent<Animator>();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        

        if (currentHealth <= 0 && gameObject.tag == "Zombie")
        {
            zombieAnimator.SetBool("isDead", true);
            
            zombie.GetComponent<ZombieAI>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            
        }
        if (currentHealth <= 0 && gameObject.tag == "Object")
        {
            Destroy();
        }

    }
  
    
    private void Destroy()
    {
        gameObject.SetActive(false);
        
        
    }
    
}
