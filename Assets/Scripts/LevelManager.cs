using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Environment objects")]
    [SerializeField] GameObject ball;
    [SerializeField] Transform pivotPoint;
    [SerializeField] GameObject blockLeft;
    [SerializeField] GameObject blockMiddle;
    [SerializeField] GameObject blockRight;
    [SerializeField] Defender defender;
    [SerializeField] UIManager managerUI;

    float startingGameSpeed = 1f;
    float currentGameSpeed;
    float nextLevelDelay = 1f;
    int blockCount = 0;
    int ballCount = 0;
    int currentLevel = 1;
    string currentLevelText = "Current Level: ";


    // Start is called before the first frame update
    void Start()
    {
        currentGameSpeed = startingGameSpeed;
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
        managerUI.ShowCurrentLevel();
        defender.IncreaseSpeed();
        CreateNewBlocks();
    }

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}
