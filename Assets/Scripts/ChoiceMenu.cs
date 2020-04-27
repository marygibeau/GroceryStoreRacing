using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject choiceMenuUI;
    public GameObject scoreUI;
    public SceneMovementManager sceneMover;
    public ChoiceGenerator choiceGenerator;

    void Start() {
        sceneMover = (SceneMovementManager)GameObject.FindObjectOfType(typeof(SceneMovementManager));
        // choiceGenerator = (ChoiceGenerator)GameObject.FindObjectOfType(typeof(ChoiceGenerator));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause() {
        choiceGenerator.GenerateChoice();
        choiceMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        sceneMover.TranslateScene();
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume() {
        choiceMenuUI.SetActive(false);
        scoreUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public bool GetIsPaused() {
        return isPaused;
    }
}
