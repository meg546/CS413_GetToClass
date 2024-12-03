using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    float time;
    int secs;
    int mins;
    int score = 1000;
    // Start is called before the first frame update
    void Start()
    {
        time = Timer.time;
        secs = Mathf.FloorToInt(time % 60);
        mins = Mathf.FloorToInt(time / 60);
        timerText.text = string.Format("Final Time: {0:00}:{1:00}", mins, secs);

        score -= ((int)time / 10) * 50;
        scoreText.text = string.Format("Final Score: {0000}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
