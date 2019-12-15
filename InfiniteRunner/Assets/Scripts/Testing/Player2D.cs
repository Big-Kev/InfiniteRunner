using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public Rigidbody2D m_rigidbody;
    Vector2 m_velocity;
    public float scrollSpeed = 100;
    public float gravity = -9;
    public float jumpHeight = 100;
    // Start is called before the first frame update
    void Start()
    {
        m_velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded())
        {
            m_velocity.y += jumpHeight;
        }


        if (!grounded())
        {
            m_velocity.y += gravity;
        }



        

        m_rigidbody.velocity = m_velocity;

        

    }


    bool grounded()
    {
        RaycastHit hit;
        if (Physics2D.Raycast(transform.position - new Vector3(0, 1.1f, 0), Vector2.down, 0.1f))
        {
            Debug.DrawRay(transform.position - new Vector3(0, 1, 0), Vector2.down);
            return true;
        }

        return false;
    }
}
