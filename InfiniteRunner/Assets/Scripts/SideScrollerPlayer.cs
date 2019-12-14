using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerPlayer : MonoBehaviour
{
    public bool moving;
    private bool canJump;

    public float moveSpeed;

    

    [Tooltip("In Meters")]
    public float jumpHeight;

    private float jumpVelocity;
    private Vector2 velocity;
    Rigidbody m_rigidbody;

    float gravity = 9.8f;

    public bool test = false;

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
        //adds gravity force
        velocity.y -= gravity * Time.deltaTime;

      if (isGrounded())
      {
         //   velocity.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpVelocity;
            }
       }

        m_rigidbody.velocity = velocity;//Apply calculated velocity to rigidbody
    }

    private bool isGrounded()//Returns true if grounded
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position - new Vector3(0,0.5f,0), Vector3.down, out hit, 0.5f))
        {
            Debug.Log("Grounded");
            return test;
        }


        return test;
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




    private void OnTriggerStay(Collider other)
    {
        test = true;
    }
    private void OnTriggerExit(Collider other)
    {
        test = false;
    }
}