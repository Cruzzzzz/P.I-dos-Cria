using UnityEngine;
using UnityEngine.UI; // precisa para Button

public class InteracaoNPC : MonoBehaviour
{
    [SerializeField] private GameObject botaoInteragir;
    // pode ser o Button direto ou só o GameObject do botão

    void Start()
    {
        botaoInteragir.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            botaoInteragir.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            botaoInteragir.SetActive(false);
    }
}

