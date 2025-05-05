using UnityEngine;

public class ShopOpener : MonoBehaviour
{
    public GameObject shopPanel; 
    private NPC_Dialogue npcDialogue; 

    void Start()
    {
        npcDialogue = GetComponent<NPC_Dialogue>();
        if (shopPanel != null)
        {
            shopPanel.SetActive(false); 
        }
    }

    void Update()
    {
        if (npcDialogue != null && !npcDialogue.startDialogue && !npcDialogue.dialoguePanel.activeSelf)
        {
            OpenShop();
        }
    }

    void OpenShop()
    {
        if (shopPanel != null && !shopPanel.activeSelf)
        {
            shopPanel.SetActive(true);
            FindAnyObjectByType<Player>().speed = 0f;
            FindAnyObjectByType<Fire>().characterControllerEnable = false;
        }
    }

    public void CloseShop()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(false);
            FindAnyObjectByType<Player>().speed = 5f;
            FindAnyObjectByType<Fire>().characterControllerEnable = true;
        }
    }
}
