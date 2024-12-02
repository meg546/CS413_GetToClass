using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.CollectPowerUp(); // Call the CollectPowerUp method
            Destroy(gameObject); // Destroy the current power-up
        }
    }
}
