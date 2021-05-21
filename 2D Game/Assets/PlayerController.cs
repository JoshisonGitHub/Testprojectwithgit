using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;
    public float gravity = -2;
    public float jumpSpeed = 1;
    private Vector2 direction = Vector2.zero;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            direction.y = jumpSpeed;
        }
        else{
            direction.y -= gravity * Time.deltaTime;
        }

        controller.Move(direction * Time.deltaTime);
        
    }
}
