using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealJump : MonoBehaviour
{

    private CharacterController controller;

    private float gravity = 9.81f;
    private float verticalVelocity;
    private float baseMouvement = 3.0f;
    private float mouvement;

    [SerializeField]
    private float jumpForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            mouvement = baseMouvement;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                
            }
        }
        else
        {
            mouvement = baseMouvement / 3.0f;
            verticalVelocity -= gravity * Time.deltaTime; 

        }
        //Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        //controller.Move(moveVector * Time.deltaTime);

        Vector3 moveVector = new Vector3(0,0,0);
        moveVector.x = Input.GetAxis("Horizontal")* mouvement;
        moveVector.y = verticalVelocity;
        moveVector.z = Input.GetAxis("Vertical")* mouvement;
        controller.Move(moveVector * Time.deltaTime);
    }
}
