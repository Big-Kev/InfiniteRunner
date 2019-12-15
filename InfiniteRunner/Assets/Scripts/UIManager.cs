using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//UI Manager updates the game UI while in a level
//Update functions should be called when a value is modified
public class UIManager : MonoBehaviour
{
    //setting up singleton instance of the UImanager
    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;

    private void Awake()
    {
        gameOver.enabled = false;
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

    //UI Manager Variables
    public Text currentScore;

    public Text gameOver;

    //updates text for score - Ensure this is called when updating the score
    public void UpdateScoreText()
    {
        currentScore.text = GameManager.Instance.GetScore().ToString();
    }
    public void endGame()
    {
        gameOver.enabled = true;
        gameOver.text = "Game over your score was: " + GameManager.Instance.GetScore().ToString();
    }

}
