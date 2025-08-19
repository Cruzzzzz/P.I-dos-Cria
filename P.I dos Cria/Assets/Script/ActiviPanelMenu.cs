using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiviPanelMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isPaused = false;

    public PlayerHealth player; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanelAndPause();
        }
    }
    public void TogglePanelAndPause()
    {
        if (panel != null)
        {
            isPaused = !isPaused;
            panel.SetActive(isPaused);
            if (isPaused)
            {
                Time.timeScale = 0f; 
                AudioListener.pause = true; 
                
            }
            else
            {
                Time.timeScale = 1f; 
                AudioListener.pause = false; 
            }
        }
        else
        {
            Debug.LogWarning("Nenhum Panel atribuído ao script TogglePanelWithESC");
        }
    }
    public void ClosePanelAndUnpause()
    {
        isPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
    }
    public void SaveButton()
    {
        SaveSystem.SavePlayer(player, PlayerMoney.Instance);
    }
}
