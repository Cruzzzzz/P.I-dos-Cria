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

    // Chamado quando o diálogo termina (substitui a verificação no Update)
    public void OnDialogueEnd()
    {
        if (shopPanel != null && !shopPanel.activeSelf)
        {
            OpenShop();
        }
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        FindAnyObjectByType<Player>().speed = 0f;
        FindAnyObjectByType<Fire>().characterControllerEnable = false;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        FindAnyObjectByType<Player>().speed = 5f;
        FindAnyObjectByType<Fire>().characterControllerEnable = true;
    }
}
