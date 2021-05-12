using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public variables 
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool alive;
   


    //private variables
    Vector3 velocity;
    Vector3 moveDirection;
    

    void Start() {

    }

    void Update() {

        //Move player
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(x, 0, z);
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            
            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpHeight;
            }
        
        }
        moveDirection.y += gravity * Time.deltaTime;
        controller.Move(moveDirection * speed * Time.deltaTime);

    }

    void OnTriggerEnter (Collider other)
        {
            if(other.tag == "Enemy")
            {
                Debug.Log("Collision!");
                SceneManager.LoadScene("Game Over");
            }
        }


}

