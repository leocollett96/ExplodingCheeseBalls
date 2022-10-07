using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    public Rigidbody selfRigidbody;
    public Vector3 jump;
    public int forceConst = 50;
    public float jumpForce = 3.0f;
    public bool isGrounded;
    public AudioSource bounceAudio;

    private bool canJump;

    [SerializeField] private int PlayerIndex;
    [SerializeField] private float speed = 2f;
    [SerializeField] private PlayerTurn playerTurn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        if (TurnManager.GetInstance().IsItPlayerTurn(PlayerIndex))
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                bounceAudio.Play();
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("Horizontal"));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
            }
        }
    }

    
    
      
 }

    
    
    
     
       

         

    

   


    




