using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour
{
    [Header("Configurações do NPC")]
    [SerializeField]private string npcName;
    [SerializeField]private Sprite spriteNPC;

    [Header("Diálogo")]
    [SerializeField]private string[] dialogueNPC;
    [SerializeField] private int dialogueIndex;

    [Header("Componentes")]
    [SerializeField]private GameObject dialoguePanel;
    [SerializeField]private TMP_Text dialogueText;
    [SerializeField]private TMP_Text nameNPC;
    [SerializeField]private Image imageNPC;

    [Header("Controle")]
    [SerializeField]private bool readyToSpeak;
    [SerializeField]private bool startDialogue;

    private bool isTyping = false;
    private Coroutine typingCoroutine;


    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToSpeak)
        {
            if (!startDialogue)
            {
                FindAnyObjectByType<Player>().speed = 0f;
                StartDialogue();
            }
            else
            {
                if (isTyping)
                {
                    StopCoroutine(typingCoroutine);
                    dialogueText.text = dialogueNPC[dialogueIndex];
                    isTyping = false;
                }
                else
                {
                    NextDialogue();
                }
            }
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueNPC.Length)
        {
            typingCoroutine = StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            FindAnyObjectByType<Player>().speed = 5f;

            ShopOpener shopOpener = GetComponent<ShopOpener>();
            if (shopOpener != null)
            {
                shopOpener.OnDialogueEnd();
            }
        }
    }

    void StartDialogue()
    {
        nameNPC.text = npcName; 
        imageNPC.sprite = spriteNPC;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        typingCoroutine = StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        isTyping = true;

        foreach (char letter in dialogueNPC[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        isTyping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            readyToSpeak = false;
        }
    }
}