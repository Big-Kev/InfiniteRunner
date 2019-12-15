using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerPlayer : MonoBehaviour
{
    public enum MoveType
    {
        Run = 0, Jump, Slide, Dash
    }

    [Tooltip("Players current movement style")]
    public MoveType m_movetype;

    [Tooltip("Is the player moving")]
    public bool moving;

    [Tooltip("Players Movement speed")]
    public float moveSpeed;

    [Tooltip("In Meters")]
    public float jumpHeight;


    private bool canJump;

    private float jumpVelocity;
    private Vector2 velocity;
    Rigidbody m_rigidbody;

    float gravity = 9.8f;

    public bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody>();
        jumpVelocity = ConvertJumpHeight(jumpHeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)//sets velocity if moving
        {
            velocity.x = moveSpeed;
        }

        if (isGrounded())
        {
            //velocity.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpVelocity;
            }
        }
        else
        {
            //adds gravity force if not grounded
            velocity.y -= gravity * Time.deltaTime;
        }

        m_rigidbody.velocity = velocity;//Apply calculated velocity to rigidbody
        updateMoveType();
    }

    private bool isGrounded()//Returns true if grounded
    {
        return grounded;
    }

    private float ConvertJumpHeight(float height)//Convert from meters to inital velocity
    {
        float velocity;

        velocity = Mathf.Sqrt((2.0f * gravity * height));//Inital Velocity from height

        return velocity;
    }
    private float ConvertSpeed(float speed)//converts from meters per second to velocity
    {
        float velocity = speed;
        //convert to meters per second
        return velocity;
    }

    void updateMoveType()
    {
        if (isGrounded())
        {
            m_movetype = MoveType.Run;
        }
        else
        {
            m_movetype = MoveType.Jump;
        }

    }

    //toggles grounded bool based on triggerBox
    //triggerbox should be smaller than normal collider & slightly lower than the chacter
    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        grounded = false;
    }
}