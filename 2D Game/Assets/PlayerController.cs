using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float g;
    private float axisx, axisy;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        axisx = Input.GetAxis("Horizontal");
        axisy = Input.GetAxis("Vertical");
        Vector2 mover;

        if((Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) || (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)){
            Debug.Log("grounded");
            mover = Vector2(axisx, g);
        }
        else{
            g = -5;
            c
        }

        controller.Move(); //takes a vector, should be scaled + multiplied by Time.deltaTime
        
    }
}
