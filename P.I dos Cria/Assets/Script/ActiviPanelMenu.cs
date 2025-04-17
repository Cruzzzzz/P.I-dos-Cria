using Unity.VisualScripting;
using UnityEngine;

public class ActiviPanelMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isPaused = false;
    private Fire playerShooting; 

    void Start()
    {
        playerShooting = FindObjectOfType<Fire>();

        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        // Tecla ESC para pausar/despausar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Bloqueia o Fire1 quando pausado
        if (isPaused && Input.GetButtonDown("Fire1"))
        {
            return;
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        // Ativa/desativa o panel
        if (panel != null)
        {
            panel.SetActive(isPaused);
        }

        // Pausa/despausa o jogo
        Time.timeScale = isPaused ? 0f : 1f;
        AudioListener.pause = isPaused;

        // Desativa/reativa o sistema de Fire
        if (playerShooting != null)
        {
            playerShooting.SetShootingEnabled(!isPaused);
        }
    }

    public void ClosePanel()
    {
        isPaused = false;
        if (panel != null)
        {
            panel.SetActive(false);
        }
        Time.timeScale = 1f;
        AudioListener.pause = false;

        // Reativa o disparo ao fechar o panel
        if (playerShooting != null)
        {
            playerShooting.SetShootingEnabled(true);
        }
    }
}
