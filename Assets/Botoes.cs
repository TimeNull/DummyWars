using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public void Jogar ()
    {
        SceneManager.LoadScene("Maranza");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Sair()
    {
        Application.Quit();
    }
}