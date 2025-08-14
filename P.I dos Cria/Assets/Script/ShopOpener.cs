using UnityEngine;

public class ShopOpener : MonoBehaviour
{
    [SerializeField]private GameObject shopPanel;
    void Start()
    {
        if (shopPanel != null)
        {
            shopPanel.SetActive(false);
        }
    }
    public void OnDialogueEnd()
    {
        if (shopPanel != null && !shopPanel.activeSelf)
        {
            OpenShop();
        }
    }

    void OpenShop()
    {
        shopPanel.SetActive(true);
        FindAnyObjectByType<Player>().speed = 0f;
        FindAnyObjectByType<Fire>().canShoot = false;
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        FindAnyObjectByType<Player>().speed = 5f;
        FindAnyObjectByType<Fire>().canShoot = true;
    }
}
