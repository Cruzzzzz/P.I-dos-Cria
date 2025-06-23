using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.PackageManager;

public class ShopSystem : MonoBehaviour
{
    [Header("Configurações da Loja")]
    [SerializeField] private int damageCost = 12;
    [SerializeField] private float damageUpgrade = 0.5f;

    [SerializeField] private int speedFireCost = 10;
    [SerializeField] private float speedUpgradeFireRate = 0.1f;

    [Header("UI de Erro")]
    [SerializeField] private TMP_Text erro;

    [Header("Referências")]
    [SerializeField] private Fire fireScript;

    [Header("Textos dos Botões")]
    [SerializeField] private TMP_Text damageButtonText;
    [SerializeField] private TMP_Text fireRateButtonText;

    private void Start()
    {
        erro.gameObject.SetActive(false);
        UpdateButtonTexts();
    }

    public void DamageUP()
    {
        if (PlayerMoney.Instance.CanAfford(damageCost))
        {
            PlayerMoney.Instance.RemoveMoney(damageCost);
            fireScript.currentDamage += damageUpgrade;

            damageCost *= 2; 
            UpdateButtonTexts();
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }

    public void FireRateUP()
    {
        if (PlayerMoney.Instance.CanAfford(speedFireCost))
        {
            PlayerMoney.Instance.RemoveMoney(speedFireCost);

            fireScript.fireRateMultiplier -= speedUpgradeFireRate;

            if (fireScript.fireRateMultiplier < 0.1f)
                fireScript.fireRateMultiplier = 0.1f;

            speedFireCost *= 2;
            UpdateButtonTexts();
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }

    private void UpdateButtonTexts()
    {
        damageButtonText.text = $"Dano = ({damageCost}$)";
        fireRateButtonText.text = $"Disparo = ({speedFireCost}$)";
    }

    private System.Collections.IEnumerator ShowError()
    {
        erro.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        erro.gameObject.SetActive(false);
    }
}



