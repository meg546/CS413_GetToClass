using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float floatSpeed = 2f;  
    public float floatHeight = 0.5f; 

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
