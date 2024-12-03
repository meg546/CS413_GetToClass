using UnityEngine;
using TMPro;

public class NPCQuestion : MonoBehaviour
{
    private Renderer npcRenderer;
    private bool playerInRange = false;

    [Header("UI Settings")]
    public GameObject chatBox;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] choiceTexts;
    public string question = "True or False";
    public string[] choices = { "True", "False", "Rome" };
    public int correctAnswerIndex = 0;

    private void Start()
    {
        npcRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (playerInRange && !chatBox.activeSelf)
        {
            ShowQuestion();
        }
    }

    private void ShowQuestion()
    {
        if (chatBox != null && questionText != null && choiceTexts.Length == choices.Length)
        {
            chatBox.SetActive(true);
            questionText.text = question;

            for (int i = 0; i < choices.Length; i++)
            {
                choiceTexts[i].text = choices[i];
            }
        }
    }

    public void HandleAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer! Proceeding...");
            chatBox.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Incorrect Answer! Try again.");
        }
    }

    public void SelectChoice(int choiceIndex)
    {
        bool isCorrect = choiceIndex == correctAnswerIndex;
        HandleAnswer(isCorrect);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered NPC");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            chatBox.SetActive(false);
        }
    }
}