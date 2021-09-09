using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Text levelText;
    [Header("References")]
    [SerializeField] LevelManager levelManager;

    float startingGameSpeed = 1f;
    float currentGameSpeed;
    string currentLevelText = "Current Level: ";

    // Start is called before the first frame update
    void Start()
    {
        PauseCanvasSetActivity(false);
        MainCanvasSetActivity(true);
        ShowCurrentLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopGame()
    {
        currentGameSpeed = 0f;
        PauseCanvasSetActivity(true);
        MainCanvasSetActivity(false);
    }

    public void ResumeGame()
    {
        currentGameSpeed = startingGameSpeed;
        PauseCanvasSetActivity(false);
        MainCanvasSetActivity(true);
    }

    void PauseCanvasSetActivity(bool isActive)
    {
        if (isActive)
        {
            pauseCanvas.SetActive(true);
        }
        else
        {
            pauseCanvas.SetActive(false);
        }
    }

    void MainCanvasSetActivity(bool isActive)
    {
        if (isActive)
        {
            mainCanvas.SetActive(true);
        }
        else
        {
            mainCanvas.SetActive(false);
        }
    }

    public void ShowCurrentLevel()
    {
        levelText.text = currentLevelText + levelManager.GetCurrentLevel().ToString();
    }

}
