using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public SpriteRenderer s;
    public Sprite[] sprites;
    public Sprite stand;
    public Sprite slash;
    public Sprite slide;
    private int counter = 0;
    public float animSpeed = 0.2f;
    private float timer = 0;
    BoxCollider box;

    
    

    public Vector3 size1;
    public Vector3 size2;
    // Start is called before the first frame update
    void Start()
    {
        size1 = new Vector3(1, 1.66f, 1);
        size2 = new Vector3(1.66f, 1, 1);

        box = this.GetComponent<BoxCollider>();

        //sprites = Resources.LoadAll<Sprite>("spritesheet");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > animSpeed)
        {
            timer = 0;

            counter++;
            if (counter > sprites.Length - 1)
            {
                counter = 0;

            }
        }
        s.sprite = sprites[counter];


        box.size = size1;

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector2(-10, this.GetComponent<Rigidbody>().velocity.y);
            s.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector2(10, this.GetComponent<Rigidbody>().velocity.y);
            s.flipX = false;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity = new Vector2(0, this.GetComponent<Rigidbody>().velocity.y);
            s.sprite = stand;

        }

        if (Input.GetKey(KeyCode.S))
        {
            s.sprite = slide;
            box.size = size2;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.33f, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.position += new Vector3(0, 0.33f, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            s.sprite = slash;
            if (Input.GetKey(KeyCode.A)) {
                s.flipX = true;
                this.GetComponent<Rigidbody>().velocity = new Vector2(-50, this.GetComponent<Rigidbody>().velocity.y);


            }
            else {
                s.flipX = false;
                this.GetComponent<Rigidbody>().velocity = new Vector2(50, this.GetComponent<Rigidbody>().velocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector2(0, 1000));

        }
        else
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector2(0, -10));

        }


    }
}
