using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image slider;

    public void SetHealth(float health, float healthMax)
    {
        slider.fillAmount = health / healthMax;
    }
}
