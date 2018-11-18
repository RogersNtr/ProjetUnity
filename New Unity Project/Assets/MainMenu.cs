using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    //AudioSource m_MyAudioSource;
    //AudioSource m_AudioSourceOptions;
    private void Start()
    {
        //m_MyAudioSource = GetComponent<AudioSource>();
        //m_AudioSourceOptions = GameObject.Find("OptionsMenu").GetComponent<AudioSource>();
        //m_MyAudioSource.volume = m_AudioSourceOptions.volume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("See you");
        Application.Quit();
    }
}
