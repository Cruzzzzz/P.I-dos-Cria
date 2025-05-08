using UnityEngine;


public class DayNightCycle : MonoBehaviour
{
    [Header("Configura��es do Ciclo")]
    [Tooltip("Dura��o de um dia completo em segundos")]
    public float dayDurationInSeconds = 60f; // 1 minuto = 1 dia

    [Header("Cores do C�u")]
    public Gradient lightColorGradient; // Gradiente para mudan�a de cor

    private Light2D globalLight; // Refer�ncia � luz global
    private float cycleProgress = 0f; // Progresso do ciclo (0 a 1)

    void Start()
    {
        // Pega a Light2D do mesmo GameObject
        globalLight = GetComponent<Light2D>();

        if (globalLight == null)
        {
            Debug.LogError("Light2D n�o encontrada! Adicione ao mesmo GameObject.");
        }
    }

    void Update()
    {
        // Atualiza o progresso do ciclo (0 a 1)
        cycleProgress += Time.deltaTime / dayDurationInSeconds;
        cycleProgress %= 1f; // Mant�m entre 0 e 1

        // Muda a cor da luz baseada no gradiente
        if (globalLight != null && lightColorGradient != null)
        {
            globalLight.color = lightColorGradient.Evaluate(cycleProgress);
        }

        // (Opcional) Ajusta a intensidade para simular amanhecer/anoitecer
        globalLight.intensity = 0.8f + Mathf.Sin(cycleProgress * Mathf.PI * 2) * 0.2f;
    }
}
