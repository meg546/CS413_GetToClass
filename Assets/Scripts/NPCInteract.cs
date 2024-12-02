using UnityEngine;
using TMPro;

public class NPCInteract : MonoBehaviour
{
    private Renderer npcRenderer;
    private bool playerInRange = false;

    [Header("Chat Settings")]
    public GameObject chatBox;
    public TextMeshProUGUI chatText;
    public string message = "Hello, World!";
    public float chatDuration = 3f;

    private void Start()
    {
        npcRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (playerInRange)
        {
            ShowChat();
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted with NPC");
    }

    private void ShowChat()
    {
        if (chatBox != null && chatText != null)
        {
            chatBox.SetActive(true);
            chatText.text = message;
            CancelInvoke(nameof(HideChat));
            Invoke(nameof(HideChat), chatDuration);
        }
    }


    private void HideChat()
    {
        chatBox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}