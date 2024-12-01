using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player S {  get; private set; }

    [Header("Inscribed")]
    public float speed = 30;
    public int powerUpCount = 0;
    public Text powerUpCounterText; // Drag the UI Text element here in the Inspector


    // Start is called before the first frame update
    void Awake()
    {
        if(S = null)
        {
            S = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // setting the axis
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");

        // Position transforming
        var pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;
    }
    public void CollectPowerUp()
    {
        powerUpCount++;
        Debug.Log("Power-Ups Collected: " + powerUpCount);

        // Update the UI text
        if (powerUpCounterText != null)
        {
            powerUpCounterText.text = "Power-Ups: " + powerUpCount;
        }
    }
}
