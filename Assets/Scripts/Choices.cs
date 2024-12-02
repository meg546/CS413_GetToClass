using UnityEngine;
using TMPro;

public class Choices : MonoBehaviour
{
    [Header("References")]
    public GameObject choicePanel;        
    public TextMeshProUGUI questionText;  
    public TextMeshProUGUI[] choiceTexts; 

    private NPCQuestion currentNPC;       
    public void ShowChoices(string question, string[] choices, NPCQuestion npc)
    {
        choicePanel.SetActive(true);          
        questionText.text = question;         
        currentNPC = npc;                    

        for (int i = 0; i < choices.Length; i++)
        {
            if (i < choiceTexts.Length)
            {
                choiceTexts[i].text = choices[i];
            }
        }
    }
    public void SelectChoice(int choiceIndex)
    {
        if (currentNPC == null)
        {
            Debug.LogError("No current NPC is set!");
            return;
        }
        bool isCorrect = choiceIndex == currentNPC.correctAnswerIndex;
        choicePanel.SetActive(false);
        currentNPC.HandleAnswer(isCorrect);
        currentNPC = null;
    }
}
