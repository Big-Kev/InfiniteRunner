﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class testgroundmove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(speed * Time.deltaTime, 0 ,0 );
    }
}
