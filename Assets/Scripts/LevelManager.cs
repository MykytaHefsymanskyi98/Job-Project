using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject pauseCanvas;

    float startingGameSpeed = 1f;
    float currentGameSpeed;
    int blockCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentGameSpeed = startingGameSpeed;
        PauseCanvasSetActivity(false);
        MainCanvasSetActivity(true);
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
            Debug.Log("Blocks destroyed");
        }
    }
}
