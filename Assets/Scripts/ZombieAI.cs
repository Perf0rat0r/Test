using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{   
    [SerializeField]
    private int damage = 20 ;
    [SerializeField]
    private NavMeshAgent navMesh;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotationSpeed = 120f;
    [SerializeField]
    private Transform visibilityRef; 
    public enum AIState { idle, chasing, attack, playerKilled};
    public AIState aiState = AIState.idle;
    public float distanceTreshhold = 10f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator playerAnimator;
    
    [SerializeField]
    private GameObject Player;     
    


    


    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        StartCoroutine(Think());
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
   
    IEnumerator Think()
    {
        while(true)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            switch (aiState)
            {
                case AIState.idle:
                    if(animator.GetBool("isDead")) break;
                    OnIdle(dist);
                break;

                case AIState.chasing:
                    if(animator.GetBool("isDead")) break;
                    OnChasing(dist);
                break;

                case AIState.attack:
                    if(animator.GetBool("isDead")) break;
                    OnAttack(dist);
                break;
                case AIState.playerKilled:
                    
                    PlayerIsKillde();
                break;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }


    void OnChasing(float dist)
    {
       if(playerAnimator.GetBool("isDead")) aiState = AIState.playerKilled;
          //dist = Vector3.Distance(target.position, transform.position);
         if (dist < 1.5f)
                {
                    aiState = AIState.attack;
                    animator.SetBool("isAttacking", true);
                    
                }
        if (dist < 7f)
        {
            RotateTowards(target);
        }
            if (canSeePlayer() == false)
            {
                aiState = AIState.idle;
                animator.SetBool("isWalking", false);
                
            }
                    
                    navMesh.SetDestination(target.position);
         
    }

    void OnAttack(float dist)
    {
        if(playerAnimator.GetBool("isDead")) aiState = AIState.playerKilled;
        RotateTowards(target);
       navMesh.SetDestination(transform.position);
             if (dist > 2f)
                {
                    aiState = AIState.idle;
                    animator.SetBool("isAttacking", false);
                }
    }

    void OnIdle(float dist)
    {
            if(playerAnimator.GetBool("isDead")) aiState = AIState.playerKilled;
        //float dist = Vector3.Distance(target.position, transform.position);
                if (canSeePlayer())
            {
                aiState = AIState.chasing;
                animator.SetBool("isWalking", true);
            }
            animator.SetBool("isAttacking", false);
            navMesh.SetDestination(transform.position);
    }

    bool canSeePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, direction);
        Ray ray = new Ray(visibilityRef.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, distanceTreshhold))
        {
            if (hit.collider.tag == "Player" && angle < 90f)
            {
                return true;
            }
        }
        return false;
    }

    public void PlayerTakeDamage()
    {
        var playerHealth = Player.GetComponent<PlayerHealth>();
        playerHealth.TakeDamagePlayer(damage);
    }

    private void PlayerIsKillde()
    {
        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", false);
        
    }

     private void RotateTowards (Transform target)
      {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("ZombieDeath"))
        {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
      }
}
