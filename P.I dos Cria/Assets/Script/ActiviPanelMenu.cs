using Unity.VisualScripting;
using UnityEngine;

public class ActiviPanelMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Refer�ncia ao Panel no Inspector
    private bool isPaused = false;

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Inverte o estado de ativa��o do Panel e pausa/despausa o jogo
            TogglePanelAndPause();
        }
    }

    // M�todo para alternar o estado do Panel e pausa do jogo
    public void TogglePanelAndPause()
    {
        if (panel != null)
        {
            // Inverte o estado atual
            isPaused = !isPaused;

            // Ativa/desativa o panel
            panel.SetActive(isPaused);

            // Pausa/despausa o jogo
            if (isPaused)
            {
                Time.timeScale = 0f; // Pausa o jogo
                AudioListener.pause = true; // Pausa os �udios
                
            }
            else
            {
                Time.timeScale = 1f; // Despausa o jogo
                AudioListener.pause = false; // Despausa os �udios
            }
        }
        else
        {
            Debug.LogWarning("Nenhum Panel atribu�do ao script TogglePanelWithESC");
        }
    }

    // M�todo opcional para fechar o panel e despausar por bot�o UI
    public void ClosePanelAndUnpause()
    {
        isPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
