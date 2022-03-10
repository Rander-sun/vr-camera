using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    
    private Animator _animator;
    
    public float walkSpeed = 3f;
    
    public float gravity = -9.81f;
    
    Vector3 velocity;

    public Transform groundCheck;
    
    public float groundDistance = 0.4f;

    public LayerMask groundMask;
    
    bool isGrounded;

    public float jumpHeight = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//Detect the ground
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        
        controller.Move(move * walkSpeed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        _animator.SetFloat("Speed",move.magnitude);
    }
}
