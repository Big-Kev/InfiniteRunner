using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        //find if levelsegment exists
        if(other.GetComponent<LevelSegment>() != null)
        {
            other.GetComponent<LevelSegment>().removeSegment();
        }
        if (other.GetComponentInParent<LevelSegment>() != null)
        {
            other.GetComponent<LevelSegment>().removeSegment();
        }
    
        if (other.GetComponent<SideScrollerPlayer>() != null)
        {
            GameManager.Instance.currentGameState = GameManager.GameState.GameOver;
        }
        if (other.GetComponentInParent<SideScrollerPlayer>() != null)
        {
            GameManager.Instance.currentGameState = GameManager.GameState.GameOver;
        }
    }
}
