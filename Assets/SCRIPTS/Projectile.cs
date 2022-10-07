using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody projectileBody;
   
    
    private bool isActive;
    public float damage = 30f;
    public GameObject explosion;

    AudioSource audioSource;
    

     void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }



    public void Initialize()
    {
        isActive = true;
        projectileBody.AddForce(transform.forward * 600f + transform.up * 200f);
    }

    void Update()
    {
        if (isActive)
        {
            Debug.Log(transform.forward);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            audioSource.Play();
            hit.GetComponent<PlayerHealth>().health -= damage;

            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;

            
        }

    
       
       

        
    }


}
