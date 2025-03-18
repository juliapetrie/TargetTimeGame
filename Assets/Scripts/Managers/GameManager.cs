using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton

    public delegate void OnGameStart();
   public static event OnGameStart StartGame;

   public delegate void OnGameEnd();
   public static event OnGameEnd EndGame;

    private float score;
    public float plsScore = 0;
   // public float PlsScore { get { return plsScore; } } //added this instead of line above
    public float Score {get { return score; } }

    private bool shouldCreateHitGraphic = false;
    public bool ShouldCreateHitGraphic
    {
        get{
            return shouldCreateHitGraphic;
        }


    }

    public void PlayerScored(float targetValue)
    {
        score = score + targetValue;

        //plsScore += score;
        plsScore += score / 100;
        //Debug.Log(plsScore);
        Debug.Log($"total score: <color=yellow> {plsScore}</color> ");

        Debug.Log(score);
    }

     public void GameStart()
    {
        Debug.Log("<color=green>Game Started</color>");
        StartGame();
        shouldCreateHitGraphic = true;
    }




   static GameManager instance;
    // public float TotalScore; //added this

    // float totalScore = GameManager.Instance.TotalScore; // added this

   public static GameManager Instance { get { return instance;} }
   private void Awake()
   {

    if(instance == null)
        instance = this;
    else
        Destroy(this.gameObject);

    DontDestroyOnLoad(this);
   }
   #endregion

    public void GameOver()
    {
        EndGame();
    }

   

   

}


// public class GameManager : MonoBehaviour
// {
//     public static GameManager Instance;
//     private int totalScore = 0;

//     private void Awake()
//     {
//         Instance = this;
//     }

//     public void PlayerScored(float scoreValue)
//     {
//         totalScore += (int)scoreValue;
//         Debug.Log($"Player scored {scoreValue} points! Total score: {totalScore}");
//     }

// }






