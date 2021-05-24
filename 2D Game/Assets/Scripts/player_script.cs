using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
    public CharacterController controller;

    public float speed;

    public float g = -2;
    private float axisx;
    private float axisy;

    private Vector2 moveinput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        axisx = Input.GetAxis("Horizontal");
        
        axisy = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded || Input.GetKeyDown(KeyCode.W) && controller.isGrounded)
        {
            //Debug.Log("grounded");
            moveinput = new Vector2(axisx, 20);
        }
        else
        {
            moveinput = new Vector2(axisx, g);
        }

       
        controller.Move(moveinput * speed * Time.deltaTime);
    }
}

