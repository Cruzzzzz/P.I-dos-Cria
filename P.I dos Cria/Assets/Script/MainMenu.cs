using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject opcoes;
    public GameObject preto;

    public void Jogar()
    {

        SceneManager.LoadScene("Cruz");

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

    }

}