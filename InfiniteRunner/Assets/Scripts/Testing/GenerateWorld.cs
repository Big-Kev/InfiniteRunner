using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    public GameObject prefab;
    public float width;
    public float spawns;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawns; i++)
        {
            
            float f = Random.Range(1, 10);
            GameObject go = Instantiate(prefab);
            go.transform.position = transform.position + new Vector3(width * i, 0, 0);
            go.transform.GetChild(0).transform.localScale +=  new Vector3(0, f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
