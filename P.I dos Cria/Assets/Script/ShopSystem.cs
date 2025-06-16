using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [Header("variaveis da loja")]

    private int playerCurrent;
    [SerializeField] private float UpDamage = 0.5f;
    [SerializeField] private int DMG = 12;

    // [SerializeField] 

    [Header("variaveis da de botoes")]


    [SerializeField] private TMP_Text Erro;


    private void Start()
    {
        playerCurrent = GetComponent<PlayerMoney>().currentMoney;
        Erro.gameObject.SetActive(false);
    }

    public void DamageUP()
    {
        if (playerCurrent >= DMG)
        {
            playerCurrent -= DMG;
            UpDamage += GetComponent<Bullet>().baseDamage;
        }
       
    }
}

