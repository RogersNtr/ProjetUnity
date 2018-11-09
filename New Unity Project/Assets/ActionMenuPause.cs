using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionMenuPause : MonoBehaviour {
    GameObject canvas;
   
    public void ResumeGame()
    {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Debug.Log("See you");
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
