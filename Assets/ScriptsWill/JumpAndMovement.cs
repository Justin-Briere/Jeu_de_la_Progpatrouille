using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float jumpForce = 350.0f;

    [SerializeField]
    private float divisionOfSpeedInAir = 5;

    private bool OnGround = false;

    private float cst = 1;

    private Rigidbody player;

    private Vector3 direction;

    static private Vector3[] directions = new[]
    {
        new Vector3(0,0,1),
        new Vector3(-1,0,0),
        new Vector3(0,0,-1),
        new Vector3(1,0,0),
    };

    void Start()
    {
        player = GetComponent<Rigidbody >();
    }

    void Update()
    {
        if(OnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))            
                MakeJump();          
        }
        else
        {
            cst = divisionOfSpeedInAir;
        }

        if (direction != Vector3.zero)
            Move(direction.normalized);

        direction = new Vector3();
    }
    public void OnCollisionEnter(Collision collision) //possibilité de rajouter layer
    {
        if(collision.gameObject.layer == 12)
        {
            OnGround = true;
            cst = 1;
        }

    }

    public void MakeJump()
    {
        Vector3 moveVector = new Vector3(0, jumpForce, 0);
        player.AddForce(moveVector);
        OnGround = false;
    }
    public void AddDirection(int directionIndex) => direction += directions[directionIndex];
    private void Move(Vector3 direction) => transform.Translate(direction * (speed/cst * Time.deltaTime));
}



