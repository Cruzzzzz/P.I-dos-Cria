using Unity.VisualScripting;
using UnityEngine;

public class ActiviPanelMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject panel;
    private bool isPaused = false;

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
    public void ClosePanelAndUnpause() //Opicional!
    {
        isPaused = false;
        panel.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}
