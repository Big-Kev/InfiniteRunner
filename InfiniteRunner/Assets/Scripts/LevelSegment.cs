using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSegment : MonoBehaviour
{
    public Transform EndConnector, StartConnector;
    public Transform[] CoinPositions;
    public GameObject coinPrefab;
    [Range(0, 100)][Tooltip("In Percentage")]
    public float coinSpawnChance = 100;

    void Start()
    {
        
        if (CoinPositions.Length > 0 && coinPrefab != null)
        {
            foreach(Transform t in CoinPositions)
            {
                GameObject thisCoin = Instantiate(coinPrefab);
                thisCoin.transform.position = t.transform.position;
            }
        }
    }

}
