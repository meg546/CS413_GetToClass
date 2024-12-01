using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float amplitude = 0.25f; // Height of the float
    public float frequency = 1.5f;  // Speed of the float

    private Vector3 startPos;

    void Start()
    {
        // Save the starting position above the ground level to prevent clipping
        startPos = transform.position;

        // Adjust starting Y position to avoid clipping at the lowest point
        startPos.y += amplitude;
    }

    void Update()
    {
        // Calculate new position relative to the starting position
        Vector3 tempPos = startPos;
        tempPos.y += Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply the new position
        transform.position = tempPos;
    }
}
