using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private GameObject menuGameOver;
    // Start is called before the first frame update
    public void GameOver()
    {
        Time.timeScale = 0f;
        menuGameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Salir()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
