using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandyCoded;
using CandyCoded.HapticFeedback;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public int countTracks,numberOfMoves;
    public bool victoryBool;
    public bool loseBool = false;
    public GameObject victoryScreen;
    void Start()
    {
        if(gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }

        countTracks = GameObject.FindGameObjectsWithTag("Path").Length;
        numberOfMoves = countTracks + 5;
        
    }

    
    public void Victory()
    {
        if(countTracks.Equals(0)&& !loseBool)
        {

            victoryBool = true;
            Debug.Log("Victoryyyy");
            Invoke("LoadVictoryScreen", 2f);          
            HapticFeedback.HeavyFeedback();
        }

    }

    public void Lose()
    {
        if(loseBool | numberOfMoves.Equals(0) && !victoryBool)
        {
            Debug.Log("hargyee");
            Handheld.Vibrate();
        }

    }

    private void LoadVictoryScreen()
    {
        victoryScreen.SetActive(true);  
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("LVL7");
    }
    
}
