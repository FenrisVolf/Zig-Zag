using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameOver = false;
    }


    void Update()
    {
        
    }

    public void StartGame()
    {
        UI_Manager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

    public void GameOver()
    {
        UI_Manager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
