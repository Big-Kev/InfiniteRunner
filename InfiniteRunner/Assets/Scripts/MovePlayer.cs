using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKey(KeyCode.D)) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000));

        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));

        }


    }
}
