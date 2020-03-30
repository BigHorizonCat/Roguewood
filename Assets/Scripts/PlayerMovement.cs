using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
    public Animator animator;
    
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;


    void Update(){
      
      //Make horizontal move from input 
      horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

      animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

      if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("Jump", true);
      }
      
    }

    public void OnLanding()
	{
        animator.SetBool("Jump", false);
    }

    void FixedUpdate(){
    	
    	// Move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }
}
