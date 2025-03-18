using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalScoreController : MonoBehaviour
//using plsScore
{
    [SerializeField] TextMeshProUGUI plsScoreText;

    void Update()
    {
        plsScoreText.text = GameManager.Instance.plsScore.ToString();
    }
}

