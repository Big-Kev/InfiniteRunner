using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //setting up singleton instance of the game manager
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    public enum GameState
    {
       GameOver = 0,
       Active,
       Paused
    }

    public GameState currentGameState;


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

    //Game Manager Variables
    private int Score;


    //changes score by input value
    public void ChangeScore(int change)
    {
        Score += change;
        UIManager.Instance.UpdateScoreText();//Updating the score in the UI Manager
    }

    //sets current score
    public void SetScore(int s)
    {
        Score = s;
        UIManager.Instance.UpdateScoreText();//Updating the score in the UI Manager
    }

    //returns current score
    public int GetScore()
    {
        return Score;
    }

    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        UIManager.Instance.endGame();
        Time.timeScale = 0;
    }
}
