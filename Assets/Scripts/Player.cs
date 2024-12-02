using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player S { get; private set; }

    public UIManager uiManager; // Assign in the Inspector
    private int powerUpCount = 0;

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }

    public void CollectPowerUp()
    {
        powerUpCount++; // Increment the power-up count
        Debug.Log("Power-Up Collected! Total: " + powerUpCount);

        if (uiManager != null)
        {
            uiManager.UpdatePowerUpCount(powerUpCount); // Update the UI
        }
        else
        {
            Debug.LogError("UI Manager is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            CollectPowerUp(); // Call the CollectPowerUp method
            Destroy(other.gameObject); // Remove the collected power-up
        }
    }
}
