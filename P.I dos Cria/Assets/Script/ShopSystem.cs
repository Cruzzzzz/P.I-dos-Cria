using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [SerializeField]

   public float Damage_Up(float dmg)
    {
       
        return dmg += 0.5f;
    }
}

