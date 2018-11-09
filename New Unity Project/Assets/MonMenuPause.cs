using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonMenuPause : MonoBehaviour {
    private bool showGUI = false;
    private GameObject canvas;
    void Start() {
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }
    
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(showGUI = !showGUI);
            Time.timeScale = Convert.ToSingle(!showGUI);
        }        
    }
 
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled.
        //Remember to always have an unsubscription for every delegate you subscribe to!

        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        canvas = GameObject.FindObjectOfType<GameObject>();
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
