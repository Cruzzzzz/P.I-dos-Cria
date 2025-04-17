using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject opcoes;

    public void Jogar()
    {

        SceneManager.LoadScene("Fase1");

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
    public void ExitMunuPlayer()
    {
        SceneManager.LoadScene("MainMenu");
    }

}