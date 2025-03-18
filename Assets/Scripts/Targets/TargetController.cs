using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetController : MonoBehaviour, ITargetInterface
{
    [SerializeField] float targetScoreValue;
    [Header("Score Components")]
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject tallyCanvas; 

    [SerializeField] float canvasYOffset = .15f;
    [SerializeField] TextMeshProUGUI scoreText;
    

     public void TargetShot(Vector3 hitpoint)
    {

        var accuracy = CalculateAccuracy(hitpoint);
       //var score = 100f * accuracy; 
        var score = 2f * accuracy; 


         //display score canvas
        Vector3 canvasPosition = new Vector3(transform.position.x, transform.position.y + canvasYOffset, transform.position.z);
        var createdCanvas = Instantiate(scoreCanvas, canvasPosition, Quaternion.identity);
        createdCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = score.ToString("0");


        Debug.Log($"Accuracy: <color=green> {accuracy}</color> | Score: <color=blue>{score}</color>");

        GameManager.Instance.PlayerScored(score);
     
        PlayAudio();
        
        GameManager.Instance.PlayerScored(targetScoreValue);

    }

    private float CalculateAccuracy(Vector3 hitpoint)
    {
        var maxdistance = .12f;

        var distanceFromTarget = Vector3.Distance(transform.position, hitpoint);

        var percentageAccuracy = (distanceFromTarget / maxdistance * 100f);

        var percentageInversion = 100f - percentageAccuracy; 

        // return percentageInversion; ORIGINAL

         if (percentageInversion < 0)
    {
        return 1;
    }
    else
    {
        return percentageInversion;
    }


    }

    public void Playanimation()
    {

    }

      public void PlayAudio()
    {

    }

}



