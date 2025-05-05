using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class NPC : MonoBehaviour, Iinteractable
{
    public NPCdialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

     public void Interact()
    {
        if(dialogueData == null)
        {
            return;
        }
        if(isDialogueActive) 
        { 

        }
    }

    public bool CanInteract()
    {
        return !isDialogueActive;
    }
}
