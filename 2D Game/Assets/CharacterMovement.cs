using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float gravity = 9.8f;
    public float speed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded){
            switch(Input.GetKeyDown()){
                case(KeyCode.W){
                    
                }
            }
        }
    }
}
