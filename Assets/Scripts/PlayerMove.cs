using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float momentumDamping = 5f;
    public float JumpHeight = 1f;

    public float air_modifier = 1f;
    public float sneak_modifier = 0.2f;

    private CharacterController myCC;

    public GameObject playerModel;

    private Vector3 inputVector;
    private Vector3 movementVector;

    public float myGravity = -9.8f; // earth gravity

    public Animator canAnim;

    private bool isWalking;
    public LayerMask Ground;

    private float GroundDistance = 1.5f;
    private Transform groundChecker;

    private float previous_frame_y;

    private PlayerCondition _playerCondition;


    // Start is called before the first frame update
    void Start()
    {
        previous_frame_y = 0f;
        myCC = GetComponent<CharacterController>();
        _playerCondition = GetComponent<PlayerCondition>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        canAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        previous_frame_y += myGravity * Time.deltaTime;
        // Holding down WASD -> give -1, 0, 1
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = playerModel.transform.TransformDirection(inputVector);

            isWalking = true;
        }
        else
        {
            // Let go of WASD -> slowly move to 0 with momentum
            inputVector = Vector3.Lerp(inputVector, new Vector3(0f, previous_frame_y, 0f), momentumDamping * Time.deltaTime);
            isWalking = false;
        }

        movementVector = (inputVector * (playerSpeed * _playerCondition.walkSpeedRate));
        if ((Input.GetKey("left shift") || Input.GetKey("right shift")) && isGrounded())
        {
            movementVector *= sneak_modifier;
        }
        movementVector.y = previous_frame_y;


        if (isGrounded() && movementVector.y < 0)
        {
            movementVector.y = 0f;
        } 

        if (Input.GetKeyDown("space") && isGrounded())
        { 
            movementVector.y = Mathf.Sqrt(JumpHeight * -2f * myGravity);
        }

        previous_frame_y = movementVector.y;
    }

    void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    private bool isGrounded()
    {
        groundChecker = playerModel.transform;
        float rayDistance = 100;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayDistance))
        {
            if (hit.distance > GroundDistance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false; // Physics.CheckSphere(groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
    }
}
