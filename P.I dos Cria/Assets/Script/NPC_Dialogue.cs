using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour
{
    public string[] dialogueNPC;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    public TMP_Text nameNPC;
    public Image imageNPC;
    public Sprite spriteNPC;

    public bool readyToSpeak;
    public bool startDialogue;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToSpeak)
        {
            if (!startDialogue)
            {
                FindAnyObjectByType<Player>().speed = 0f;
                FindAnyObjectByType<Fire>().characterControllerEnable = false;
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNPC[dialogueIndex])
            {
                NextDialogue();
            }

        }   
    }
    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialogueNPC.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            FindAnyObjectByType<Player>().speed = 5f;
            FindAnyObjectByType<Fire>().characterControllerEnable = true;
            ShopOpener shopOpener = GetComponent<ShopOpener>();
            if (shopOpener != null)
            {
                shopOpener.OnDialogueEnd();
            }
        }
    }
    void StartDialogue()
    {
        nameNPC.text = "Marcos";
        imageNPC.sprite = spriteNPC;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }
    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNPC[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }   
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
