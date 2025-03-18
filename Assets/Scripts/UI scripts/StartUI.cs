using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour, ITargetInterface
{
    [SerializeField] TextMeshProUGUI uiText;

     public void TargetShot(Vector3 hitpoint)
    {
        uiText.text = "The farther the target the more it's worth, gain bonus points for accuracy!"; //replace with game instructions to kill time
        Invoke("StartGame", 7f);

      
    }

    public void Playanimation()
    {
//todo
    }

    public void PlayAudio()
    {
//todo
    }

    void StartGame()
    {
        GameManager.Instance.GameStart();
        this.gameObject.SetActive(false);

    }

}
