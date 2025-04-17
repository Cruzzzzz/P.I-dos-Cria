using Unity.VisualScripting;
using UnityEngine;

public class ActiviPanelMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel; // Referência ao Panel no Inspector
    private bool isPaused = false;

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Inverte o estado de ativação do Panel e pausa/despausa o jogo
            TogglePanelAndPause();
        }
    }

    // Método para alternar o estado do Panel e pausa do jogo
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
                AudioListener.pause = true; // Pausa os áudios
                
            }
            else
            {
                Time.timeScale = 1f; // Despausa o jogo
                AudioListener.pause = false; // Despausa os áudios
            }
        }
        else
        {
            Debug.LogWarning("Nenhum Panel atribuído ao script TogglePanelWithESC");
        }
    }

    // Método opcional para fechar o panel e despausar por botão UI
    public void ClosePanelAndUnpause()
    {
        isPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
