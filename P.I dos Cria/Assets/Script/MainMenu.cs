
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public Button deleteSaveButton;

    private void Start()
    {
        if (SaveSystem.HasSave())
        {
            continueButton.gameObject.SetActive(true);
            deleteSaveButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
            deleteSaveButton.gameObject.SetActive(false);
        }
    }
    public void Play()
    {
        SaveSystem.DeleteSave();
        SceneManager.LoadScene("Fase1");
    }

    public void ContinueGame()
    {
        if (SaveSystem.HasSave())
        {
            SaveSystem.isLoading = true; 
            SceneManager.LoadScene("Fase1");
        }
    }

    public void DeleteSave()
    {
        SaveSystem.DeleteSave();

        continueButton.gameObject.SetActive(false);
        deleteSaveButton.gameObject.SetActive(false);
    }

    public void Options()
    {
        SceneManager.LoadScene("Opcoes");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu Do Gamezada");
    }
}