using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] Text levelText;
    [Header("Environment objects")]
    [SerializeField] GameObject ball;
    [SerializeField] Transform pivotPoint;
    [SerializeField] GameObject blockLeft;
    [SerializeField] GameObject blockMiddle;
    [SerializeField] GameObject blockRight;
    [SerializeField] Defender defender;

    float startingGameSpeed = 1f;
    float currentGameSpeed;
    float nextLevelDelay = 1f;
    int blockCount = 0;
    int ballCount = 0;
    int currentLevel = 0;
    string currentLevelText = "Current Level: ";


    // Start is called before the first frame update
    void Start()
    {
        currentGameSpeed = startingGameSpeed;
        PauseCanvasSetActivity(false);
        MainCanvasSetActivity(true);
        currentLevel = 1;
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
        if(isActive)
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

    public void CountBlocks()
    {
        blockCount++;
    }

    public void DecreaseBlocksNumber()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            Invoke("CreateNewLevel", nextLevelDelay);
            Debug.Log("Blocks destroyed");
        }
    }

    public void CreateNewBall()
    {
        ballCount = FindObjectsOfType<Ball>().Length;
        if(ballCount > 0)
        { 
            return;
        }
        else
        {
            GameObject newBall = Instantiate(ball, pivotPoint.position, Quaternion.identity) as GameObject;
        }
    }

    void CreateNewBlocks()
    {
        Instantiate(blockLeft, blockLeft.transform.position, Quaternion.identity);
        Instantiate(blockMiddle, blockMiddle.transform.position, Quaternion.identity);
        Instantiate(blockRight, blockRight.transform.position, Quaternion.identity);
    }

    void CreateNewLevel()
    {
        currentLevel++;
        ShowCurrentLevel();
        defender.IncreaseSpeed();
        CreateNewBlocks();
    }

    public void ShowCurrentLevel()
    {
        levelText.text = currentLevelText + GetCurrentLevel().ToString();
    }

    int GetCurrentLevel()
    {
        return currentLevel;
    }
}
