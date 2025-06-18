using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.PackageManager;

public class ShopSystem : MonoBehaviour
{
    [Header("Configurações da Loja")]
    [SerializeField] private int damageCost = 12;
    [SerializeField] private float damageUpgrade = 0.5f;
    [SerializeField] private int speedFireCost = 12;
    [SerializeField] private float speedUpgradeFireRate = 0.1f;

    [Header("UI de Erro")]
    [SerializeField] private TMP_Text erro;

    [Header("Referências")]
    [SerializeField] private Fire fireScript; 

    private void Start()
    {
        erro.gameObject.SetActive(false);
    }

    public void DamageUP()
    {
        if (PlayerMoney.Instance.CanAfford(damageCost))
        {
            PlayerMoney.Instance.RemoveMoney(damageCost);
            fireScript.currentDamage += damageUpgrade;
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
            {
                fireScript.fireRateMultiplier = 0.1f;
            }
        }
        else
        {
            StartCoroutine(ShowError());
        }
    }

    private System.Collections.IEnumerator ShowError()
    {
        erro.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        erro.gameObject.SetActive(false);
    }
}


