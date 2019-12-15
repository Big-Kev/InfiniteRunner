using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //setting up singleton instance of the UImanager
    public static UIManager Instance { get { return _instance; } }
    private static UIManager _instance;

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

    //UI Manager Variables
    public Text currentScore;


    //updates text for score - Ensure this is called when updating the score
    public void UpdateScoreText()
    {
        currentScore.text = GameManager.Instance.GetScore().ToString();
    }
}
