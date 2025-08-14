using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject opcoes;
    public Button continueButton;

    void Start()
    {
        if (continueButton != null)
            continueButton.interactable = SaveSystem.SaveExists();
    }
    public void Jogar()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void ContinueGame()
    {
        if (SaveSystem.SaveExists())
            SceneManager.LoadScene("Fase1");
    }
    public void DeleteSave()
    {
        SaveSystem.DeleteSave();
    }
    public void Opcoes()
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
    public void ExitMenuPlayer()
    {
        SceneManager.LoadScene("MainMenu");
    }

}