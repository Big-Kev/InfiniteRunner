using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jump;
    Vector2 velocity;
    public Rigidbody character;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(speed, 0);
        character.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = new Vector2(speed, jump);
            character.velocity = velocity;
        }

    }
}
