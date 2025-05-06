using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public int itemPrice;
        public UnityEngine.Events.UnityEvent onPurchase; // Ação personalizada ao comprar (ex.: adicionar item ao inventário)
    }

    public ShopItem[] itemsForSale; // Itens disponíveis na loja
    public TextMeshProUGUI feedbackText; // Mensagem de erro/sucesso (opcional)
    public float feedbackDuration = 2f; // Tempo que a mensagem fica visível

    public void TryBuyItem(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= itemsForSale.Length)
        {
            Debug.LogError("Índice de item inválido!");
            return;
        }

        ShopItem item = itemsForSale[itemIndex];
        bool success = PlayerMoney.Instance.RemoveMoney(item.itemPrice);

        if (success)
        {
            // Compra bem-sucedida
            item.onPurchase.Invoke(); // Executa a ação do item (ex.: curar vida, dar arma)
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

