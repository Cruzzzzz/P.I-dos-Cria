using UnityEngine;

public class BotaoGeralNPC : MonoBehaviour
{
    public GameObject botaoUI;

    void Update()
    {
        botaoUI.SetActive(NPC_Dialogue.npcAtual != null);
    }

    public void Interagir()
    {
        if (NPC_Dialogue.npcAtual != null)
            NPC_Dialogue.npcAtual.Interagir();
    }
}
