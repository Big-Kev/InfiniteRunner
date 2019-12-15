using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(this.gameObject);
    //}

    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ChangeScore(pointValue);
        Destroy(this.gameObject);
    }
}
