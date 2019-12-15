using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //setting up singleton instance of the game manager
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    private int Score;

    private void Awake()
    {
        //Preventing duplicate insatnces
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //changes score by input value
    public void ChangeScore(int change)
    {
        Score += change;
    }

    //sets current score
    public void SetScore(int s)
    {
        Score = s;
    }

    //returns current score
    public int GetScore()
    {
        return Score;
    }

}
