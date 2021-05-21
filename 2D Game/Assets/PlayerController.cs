using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;

    //jumping
    public float gravity;
    public float jumpheight;
    public float sprintjump;
    private float originaljumpheight;
    private Vector2 direction = Vector2.zero;
    

    //left right movements
    private float speed;
    public float walkspeed;
    public float runspeed;

    //wall sliding 
   
    void Start()
    {
        originaljumpheight = jumpheight;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) || controller.isGrounded && Input.GetKeyDown(KeyCode.W) || controller.isGrounded && Input.GetKeyDown(KeyCode.UpArrow)) {
            direction.y = jumpheight;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y -= gravity * Time.deltaTime * 2;
        }
        else{
            direction.y -= gravity * Time.deltaTime ;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            jumpheight = sprintjump;
            speed = runspeed;
        }
        else
        {
            jumpheight = originaljumpheight;
            speed = walkspeed;
        }
        direction.x = Input.GetAxis("Horizontal") * speed;
        
        controller.Move(direction * Time.deltaTime);

       
    }
}
