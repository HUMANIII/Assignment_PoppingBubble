using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] 
    private Slider timerSlider;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject endGameObject;
    private IEndGame endGame;

    private float timeLeft;
    [SerializeField]
    private float maxTime;

    private void Awake()
    {
        if(timerSlider == null)
        {
           gameObject.GetComponent<Slider>();
        }
        endGame = endGameObject.GetComponent<IEndGame>();
    }

    private void Start()
    {
        InitTimer();
    }

    private void Update()
    {
        if(!endGame.IsGameRunning)
        {
            return;
        }
        
        RunningTimer();

        if(timeLeft <= 0)
        {
            endGame?.EndGame();
        }
    }

    // 타이머 초기화
    public void InitTimer()
    {
        timeLeft = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = timeLeft;
        timerText.text = timeLeft.ToString();
    }

    // 타이머 실행 동작
    private void RunningTimer()
    {
        timeLeft -= Time.deltaTime;
        timerSlider.value = timeLeft;
        timerText.text = timeLeft.ToString("F0");
    }
}
