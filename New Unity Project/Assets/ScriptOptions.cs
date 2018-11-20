using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptOptions : MonoBehaviour {

    AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    public float m_MySliderValue;

    void Start()
    {
        //Initiate the Slider value to half way
        m_MySliderValue = 0.5f;
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //m_MyAudioSource = ;
        //Play the AudioClip attached to the AudioSource on startup
        m_MyAudioSource.Play();
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }

}
