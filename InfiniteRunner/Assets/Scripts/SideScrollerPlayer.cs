using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script controlls aspects of the player such as jumping and moving
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

    //Players collision box (Edit this when sliding)
    BoxCollider box;

    //Players Slide timers
    float slideTimer;
    public float slideLength;

    private bool canJump;

    private float jumpVelocity;
    private Vector2 velocity;
    Rigidbody m_rigidbody;


    //Gravity Aplied to player
    float gravity = 9.8f;


    //Hitbox sizes for sliding
    public Vector3 size1;
    public Vector3 size2;

    public bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        //Sizes for players hitbox
        size1 = new Vector3(1, 1.66f, 1);
        size2 = new Vector3(1.66f, 1, 1);
        box = this.GetComponent<BoxCollider>();


        m_rigidbody = this.GetComponent<Rigidbody>();
        jumpVelocity = ConvertJumpHeight(jumpHeight);
    }

    // Update is called once per frame
    void Update()
    {
        //With more time this should be somewhere else
        if(GameManager.Instance.currentGameState == GameManager.GameState.GameOver && Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene("MainScene"); //didnt load properly
        }

        if (moving)//sets velocity if moving
        {
            velocity.x = moveSpeed;
        }

        //Jumping conrolls
        if (isGrounded())
        {
            //Get input(checks if mosuse is down on the right side of screen (For mobile))
            if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)) && m_movetype != MoveType.Slide)
            {
                velocity.y = jumpVelocity;
            }
        }
        else
        {
            //adds gravity force if not grounded
            velocity.y -= gravity * Time.deltaTime;
        }

        //sliding
        //Get input(checks if mosuse is down on the left side of screen (For mobile))
        if ((Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2))  && m_movetype != MoveType.Slide)
        {
            enterSlide();
        }
        //timer for characters slide
        if (m_movetype == MoveType.Slide)
        {
            slideTimer += Time.deltaTime;
            if (slideTimer > slideLength)
            {
                m_movetype = MoveType.Run;
                box.size = size1;
                transform.position += new Vector3(0, 0.33f, 0);

            }
        }



        m_rigidbody.velocity = velocity;//Apply calculated velocity to rigidbody
        updateMoveType();

        //ending game
        if (transform.position.x < 3)//Ends game if player is off the map would replace with somehing more elegant if i had more time
        {
            GameManager.Instance.GameOver();
            
        }
    }


    //sets up players slide timer and sprite
    private void enterSlide()
    {
        m_movetype = MoveType.Slide;
        box.size = size2;
        slideTimer = 0;
        transform.position += new Vector3(0, -0.33f, 0);

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


    //Updates move type this is used for sprite and determining if player may jump
    void updateMoveType()
    {
        if (m_movetype != MoveType.Slide)
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
    }

    void FixedUpdate()
    {
        grounded = false;
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