using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // For 3D collision
    {
        if (other.CompareTag("Player")) // Ensure the colliding object is the player
        {
            // Optional: Call a method on the player script
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.CollectPowerUp(); // Handle power-up collection logic
            }

            // Destroy the power-up
            Destroy(gameObject);
        }
    }
}
