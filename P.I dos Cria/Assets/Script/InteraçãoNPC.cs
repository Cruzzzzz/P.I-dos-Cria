using TMPro;
using UnityEngine;

public class InteraçãoNPC : MonoBehaviour
{
    [SerializeField] private TMP_Text Aperte_E;

    void Start()
    {
        Aperte_E.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Aperte_E.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Aperte_E.gameObject.SetActive(false);
    }
}
