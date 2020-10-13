using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float fireRate = 1;
    
    [SerializeField]
    [Range(1, 20)]
    private int damage = 20; 
    
    [SerializeField]
    private Transform shootingRef;
    [SerializeField]
    private Transform pistolTransform;

    [SerializeField]
    private ParticleSystem muzzleParticle;
    [SerializeField]
    private GameObject impactEffect;

    [SerializeField]
    private AudioSource pistolFireSource;

    [SerializeField]
    private PlayerHealth playerHealth;
    public Animator animator;

    public bool shootIsExecuted = false;

    public float impactForce = 30f;

    
    
   


    void Start ()
    {
        GameObject.Find("FireButton").GetComponent<Button>().onClick.AddListener(Shoot);
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (shootIsExecuted)
        {
            shootIsExecuted = false;
            
        }
    }

      public void Shoot()
   {    
      if (playerHealth.currentHealth > 0)
      {
        shootIsExecuted = true;
       //Debug.DrawRay(shootingRef.position, shootingRef.forward * 100, Color.red, 2f);
       animator.SetTrigger("isPistolShooting");
       muzzleParticle.Play();
       pistolFireSource.Play();
       Ray ray = new Ray(shootingRef.position, shootingRef.forward);
       RaycastHit hitInfo;
        
       if (Physics.Raycast(ray, out hitInfo, 100))
       {
           var health = hitInfo.collider.GetComponent<Health>();
             
           
           if (health != null)
           {
               health.TakeDamage(damage);
           }
           
           if (hitInfo.rigidbody != null)
           {
               hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
           }

           GameObject impactGObj = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
           Destroy(impactGObj, 1f);
       }
       }
        

   }


}
