using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Assign in the Inspector
    public Text timeText;  // Assign in the Inspector

    void Start()
    {
        // Retrieve data from PlayerPrefs
        int score = PlayerPrefs.GetInt("PlayerScore", 0);
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);

        // Display the score and time
        scoreText.text = "Score: " + score;
        timeText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
    }
}
