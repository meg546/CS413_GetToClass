using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player S { get; private set; }
    private int powerUpCount = 0;
    public TextMeshProUGUI powerUpCountText;

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }

    public void CollectPowerUp()
    {
        powerUpCount++;
        UpdatePowerUpUI();
    }

    private void UpdatePowerUpUI()
    {
        if (powerUpCountText != null)
        {
            powerUpCountText.text = "Power-Ups: " + powerUpCount.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            CollectPowerUp();
            Destroy(other.gameObject);
        }
    }

    public bool HasPowerUp()
    {
        return powerUpCount > 0;
    }

    public void UsePowerUp()
    {
        if (powerUpCount > 0)
        {
            powerUpCount--;
            UpdatePowerUpUI();
        }
    }
}
