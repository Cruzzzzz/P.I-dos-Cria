using UnityEngine;
using UnityEngine.UI;

public class InteractButtonManager : MonoBehaviour
{
    private NPC_Dialogue currentNpc;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        gameObject.SetActive(false); // começa escondido
    }

    void Start()
    {
        // garante que o OnClick chama Interact aqui
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Interact);
    }

    public void SetCurrentNPC(NPC_Dialogue npc)
    {
        currentNpc = npc;
        gameObject.SetActive(currentNpc != null);
    }

    public void ClearCurrentNPC(NPC_Dialogue npc)
    {
        // só limpa se for o mesmo que estava setado (evita sobrescrever errado)
        if (currentNpc == npc)
        {
            currentNpc = null;
            gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (currentNpc != null)
        {
            currentNpc.Interagir();
        }
    }
}
