using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] GameObject timerComponents;
    [SerializeField] Image timerGraphic;
    [SerializeField] float gameTime;



    float maxGameTime;
    bool canTimerCountDown = false;

    private void Awake() => maxGameTime = gameTime;

    private void OnEnable() => GameManager.StartGame += ActivateTimer;
    
    private void OnDisable() => GameManager.StartGame -= ActivateTimer;
    

    private void ActivateTimer()
    {
        timerComponents.SetActive(true);
        canTimerCountDown = true;

    }


  
    // Update is called once per frame
    void Update()
    {
        if(!canTimerCountDown)
        return;

        UpdateTimer();       
        CheckTimer();

    }

    private void UpdateTimer()
    {
         gameTime -= Time.deltaTime;

        var updateTimerGraphicValue = gameTime / maxGameTime;

        timerGraphic.fillAmount = updateTimerGraphicValue;


        

    }

      private void CheckTimer()
      {
        if(timerGraphic.fillAmount <= 0f)
        {
            GameManager.Instance.GameOver();
            canTimerCountDown = false;
            gameTime = maxGameTime;

            timerComponents.SetActive(false);
        }
      }
}
