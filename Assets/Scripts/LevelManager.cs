using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Debug.Log("Carregar próximo nível foi chamado.");

        SceneManager.LoadScene("nivel_2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("nivel_3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("nivel_4");
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("tela_inicial");
    }



}
