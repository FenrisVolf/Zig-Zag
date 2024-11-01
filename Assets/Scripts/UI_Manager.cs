using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject TapText;
    public GameObject MainPanel;
    public GameObject GameOverPanel;
    public Text Score;
    public Text HighScore1;
    public Text HighScore2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        HighScore1.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }

    public void GameStart()
    {
        
        TapText.SetActive(false);
        MainPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        Score.text = PlayerPrefs.GetInt("Score").ToString();
        HighScore2.text = PlayerPrefs.GetInt("HighScore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }
}
