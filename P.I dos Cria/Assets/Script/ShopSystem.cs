using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public int itemPrice;
        public UnityEngine.Events.UnityEvent onPurchase; // A��o personalizada ao comprar (ex.: adicionar item ao invent�rio)
    }

    public ShopItem[] itemsForSale; // Itens dispon�veis na loja
    public TextMeshProUGUI feedbackText; // Mensagem de erro/sucesso (opcional)
    public float feedbackDuration = 2f; // Tempo que a mensagem fica vis�vel

    public void TryBuyItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= itemsForSale.Length)
        {
            Debug.LogError("�ndice de item inv�lido!");
            return;
        }

        ShopItem item = itemsForSale[itemIndex];
        bool success = PlayerMoney.Instance.RemoveMoney(item.itemPrice);

        if (success)
        {
            // Compra bem-sucedida
            item.onPurchase.Invoke(); // Executa a a��o do item (ex.: curar vida, dar arma)
            ShowFeedback($"Comprado: {item.itemName}!", Color.green);
        }
        else
        {
            // Dinheiro insuficiente
            ShowFeedback("Dinheiro insuficiente!", Color.red);
        }
    }

    private void ShowFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
            Invoke("HideFeedback", feedbackDuration);
        }
    }

    private void HideFeedback()
    {
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false);
        }
    }
}

