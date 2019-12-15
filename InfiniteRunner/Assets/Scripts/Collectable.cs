using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter(Collider other)
    {
        //Update score in game manager
        GameManager.Instance.ChangeScore(pointValue);
        Destroy(this.gameObject);
    }
}
