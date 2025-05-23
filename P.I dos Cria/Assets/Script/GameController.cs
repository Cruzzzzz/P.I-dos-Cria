using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public ShopSystem shopSystem;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

}