using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The level segment script represents a modular piece of the level
//When creating a level segement prefab create 2 attach points for linking to the previous and next parts of the level
//Coin Positions should be empty game objects
public class LevelSegment : MonoBehaviour
{
    public LevelManager myLevel;
    public Transform EndConnector, StartConnector;
    public Transform[] CoinPositions;
    public GameObject coinPrefab;
    [Range(0, 100)]
    [Tooltip("In Percentage")]
    public float coinSpawnChance = 100;

    void Start()
    {

        if (CoinPositions.Length > 0 && coinPrefab != null)
        {
            foreach (Transform t in CoinPositions)
            {
                GameObject thisCoin = Instantiate(coinPrefab);
                thisCoin.transform.position = t.transform.position;

                thisCoin.transform.parent = this.transform;
            }
        }
    }

    //moves the level segment to a postion then ofset to the starting connector
    //use this function to connect this levelsegment to the EndConnector of the previous segment
    public void moveToStartOffset(Transform targetPosition)
    {
        Vector3 startOffset = StartConnector.position - gameObject.transform.position;
        transform.position = targetPosition.position + startOffset;
    }




    public void removeSegment()
    {
        if (myLevel != null)
        {
            myLevel.removeLevelSegment(this);
        }
        Destroy(gameObject);

    }
}