using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject run, slide;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            run.transform.rotation.eulerAngles.Set(90, 0, 0);
            //run.transform.localScale = new Vector3(2, 1, 1);
        }
        else
        {
            run.transform.rotation.eulerAngles.Set(0, 0, 0);

            //run.transform.localScale = new Vector3(1, 2, 1);
        }
    }
}
