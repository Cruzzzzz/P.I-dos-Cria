using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public int basePrice;
        public TMP_Text priceText;
        public Button buyButton;
        public int maxPurchases = 5;
        [HideInInspector] public int timesPurchased;
    }

    [Header("Itens da Loja")]
    public ShopItem damageUpgrade;
    public ShopItem fireRateUpgrade;
    public ShopItem healthRestore;

    [Header("Referências")]
    public PlayerHealth playerHealth;
    public Fire playerFire;

    void Start()
    {
        SetupShopItem(damageUpgrade, BuyDamageUpgrade);
        SetupShopItem(fireRateUpgrade, BuyFireRateUpgrade);
        SetupShopItem(healthRestore, BuyHealthRestore);
        UpdateShopUI();
    }

    private void SetupShopItem(ShopItem item, UnityEngine.Events.UnityAction action)
    {
        if (item.priceText != null)
            item.priceText.text = $"${item.basePrice}";

        if (item.buyButton != null)
        {
            item.buyButton.onClick.AddListener(action);
            item.buyButton.onClick.AddListener(UpdateShopUI);
        }
    }

    public void BuyDamageUpgrade()
    {
        if (PlayerMoney.Instance.RemoveMoney(damageUpgrade.basePrice))
        {
            Bullet.IncreaseDamage(2);
            damageUpgrade.timesPurchased++;
            damageUpgrade.basePrice = Mathf.RoundToInt(damageUpgrade.basePrice * 1.5f);
            UpdateShopUI();
        }
    }

    public void BuyFireRateUpgrade()
    {
        if (PlayerMoney.Instance.RemoveMoney(fireRateUpgrade.basePrice))
        {
            playerFire.UpgradeFireRate(0.9f);
            fireRateUpgrade.timesPurchased++;
            fireRateUpgrade.basePrice = Mathf.RoundToInt(fireRateUpgrade.basePrice * 1.3f);
            UpdateShopUI();
        }
    }

    public void BuyHealthRestore()
    {
        if (PlayerMoney.Instance.RemoveMoney(healthRestore.basePrice))
        {
            playerHealth.RestoreFullHealth();
        }
    }

    public void UpdateShopUI()
    {
        damageUpgrade.buyButton.interactable = PlayerMoney.Instance.CanAfford(damageUpgrade.basePrice) &&damageUpgrade.timesPurchased < damageUpgrade.maxPurchases;

        fireRateUpgrade.buyButton.interactable = PlayerMoney.Instance.CanAfford(fireRateUpgrade.basePrice) &&fireRateUpgrade.timesPurchased < fireRateUpgrade.maxPurchases;

        healthRestore.buyButton.interactable = PlayerMoney.Instance.CanAfford(healthRestore.basePrice);

        if (damageUpgrade.timesPurchased >= damageUpgrade.maxPurchases)
        {
                damageUpgrade.priceText.text = "ESGOTADO";
        }
        else
        {
                damageUpgrade.priceText.text = $"${damageUpgrade.basePrice}";
        }
        if (fireRateUpgrade.timesPurchased >= fireRateUpgrade.maxPurchases)
        {
                fireRateUpgrade.priceText.text = "ESGOTADO";
        }
        else
        {
            fireRateUpgrade.priceText.text = $"${fireRateUpgrade.basePrice}";
        }
        healthRestore.priceText.text = $"${healthRestore.basePrice}";
    }
}