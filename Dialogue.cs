using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class Trivia
{
    public string question;
    public string[] options;
    public int correctAnswerIndex;
}

public class Dialogue : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int dialogueIndex;
    public GameObject button;
    public GameObject skipButton;
    public GameObject tryAgainButton;

    public GameObject triviaPanel;
    public TMP_Text triviaQuestionText;
    public Button[] triviaOptionButtons;
    public List<Trivia> triviaQuestions;
    private int triviaIndex;

    public float wordSpeed;
    private bool playerRange;
    private bool isTyping;
    private bool skippedDialogue;
    private bool isTriviaActive;

    private int correctAnswers; 

    void Start()
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        triviaPanel.SetActive(false);
        correctAnswers = 0; 
    }

    void Update()
    {
        if (!skippedDialogue && playerRange && !dialoguePanel.activeInHierarchy && !isTriviaActive)
        {
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }

        if (!isTyping && dialoguePanel.activeInHierarchy && dialogueText.text == dialogue[dialogueIndex])
        {
            button.SetActive(true);
            if (Player.S != null && Player.S.HasPowerUp())
            {
                skipButton.SetActive(true);
            }
            else
            {
                skipButton.SetActive(false);
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        dialogueIndex = 0;
        dialoguePanel.SetActive(false);
    }

    public void nextLine()
    {
        button.SetActive(false);

        if (dialogueIndex < dialogue.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = "";
            StopAllCoroutines();
            StartCoroutine(Typing());
        }
        else if (triviaQuestions.Count > 0 && triviaIndex < triviaQuestions.Count)
        {
            StartTrivia();
        }
        else
        {
            zeroText();
        }
    }

    IEnumerator Typing()
    {
        isTyping = true;

        foreach (char letter in dialogue[dialogueIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        isTyping = false;
    }

    public void SkipDialogue()
    {
        if (Player.S != null && Player.S.HasPowerUp())
        {
            Player.S.UsePowerUp();
            skippedDialogue = true;
            dialoguePanel.SetActive(false);
            Debug.Log("Dialogue skipped using power-up.");
        }
        else
        {
            Debug.Log("Player has no power-ups to skip dialogue.");
        }
    }

    void StartTrivia()
    {
        isTriviaActive = true;
        dialoguePanel.SetActive(false);
        triviaPanel.SetActive(true);
        ShowTriviaQuestion();
    }

    void ShowTriviaQuestion()
    {
        if (triviaIndex < triviaQuestions.Count)
        {
            Trivia currentTrivia = triviaQuestions[triviaIndex];
            triviaQuestionText.text = currentTrivia.question;

            for (int i = 0; i < triviaOptionButtons.Length; i++)
            {
                if (i < currentTrivia.options.Length)
                {
                    triviaOptionButtons[i].gameObject.SetActive(true);
                    triviaOptionButtons[i].GetComponentInChildren<TMP_Text>().text = currentTrivia.options[i];

                    int optionIndex = i;
                    triviaOptionButtons[i].onClick.RemoveAllListeners();
                    triviaOptionButtons[i].onClick.AddListener(() => CheckTriviaAnswer(optionIndex));
                }
                else
                {
                    triviaOptionButtons[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            EndTrivia();
        }
    }

    void CheckTriviaAnswer(int selectedIndex)
    {
        Trivia currentTrivia = triviaQuestions[triviaIndex];

        if (selectedIndex == currentTrivia.correctAnswerIndex)
        {
            correctAnswers++; 
        }
        else
        {
            Debug.Log("Wrong");
        }

        triviaIndex++;
        ShowTriviaQuestion();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRange = false;
            dialoguePanel.SetActive(false);
            triviaPanel.SetActive(false);
            StopAllCoroutines();
            dialogueText.text = "";
            dialogueIndex = 0;
            triviaIndex = 0;
            correctAnswers = 0; 
        }
    }

    void EndTrivia()
    {
        isTriviaActive = false;
        triviaPanel.SetActive(false);
        triviaIndex = 0;

        if (correctAnswers >= 2)
        {
            dialoguePanel.SetActive(true);
            dialogueText.text = "You may pass.";
            button.SetActive(false);
            tryAgainButton.SetActive(false);
            dialoguePanel.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            correctAnswers = 0;
            dialoguePanel.SetActive(true);
            dialogueText.text = "You got an answer wrong. No Losers Allowed.";
            tryAgainButton.SetActive(true);
            button.SetActive(false);
        }

        correctAnswers = 0;

    }

    public void tryAgain()
    {
        SceneManager.LoadSceneAsync(1); //wa wa go back to beginning
    }
}
