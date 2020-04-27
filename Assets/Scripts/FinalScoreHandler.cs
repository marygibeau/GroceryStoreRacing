using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreHandler : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject scoreUI;
    public GameObject finalScoreUI;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsPaused() {
        return isPaused;
    }

    void Pause() {
        finalScoreUI.SetActive(true);
        scoreUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GenerateFinalScore() {
        Pause();
    }

    public void RestartMiniGame() {
        Debug.Log("Restart");
    }

    public void ContinueStory() {
        Debug.Log("Continue");
    }
}
