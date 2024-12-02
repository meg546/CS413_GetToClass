using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI powerUpCountText; // Assign in the Inspector
    private int powerUpCount = 0;

    // Call this method to update the power-up count
    public void UpdatePowerUpCount(int count)
    {
        powerUpCount = count;
        powerUpCountText.text = "Power-Ups: " + powerUpCount.ToString();
    }
}
