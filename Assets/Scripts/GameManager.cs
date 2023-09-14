using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public static Difficult difficult = Difficult.Loser;
    private bool isFinish;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] AudioClip[] bgm;

    private bool isGameOver = false;
    private GameOver gameOver = null;
    private GameClear gameClear = null;

    private void Start()
    {
        gameOver = gameOverPanel.GetComponent<GameOver>();
        gameClear = gameClearPanel.GetComponent<GameClear>();

        int a = Random.Range(0, bgm.Length);
        float volume = 0;
        switch (a)
        {
            case 0: volume = 0.7f; break;
            case 1: volume = 0.3f; break;
            case 2: volume = 0.1f; break;
        }
        SoundManager.Instance.Play(bgm[a], Sound.BGM, volume);
    }

    public void GameClear()
    {
        gameClearPanel.SetActive(true);
        gameClear.GameClearStart();
        isFinish = true;
        TimeLimit.Instance.isFinish = true;
        CommandManager.Instance.isFinish = true;
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        gameOverPanel.SetActive(true);
        gameOver.GameOverStart();

        isFinish = true;
        TimeLimit.Instance.isFinish = true;
        CommandManager.Instance.isFinish = true;
    }

    private void Update()
    {
        if (!isFinish) return;
        if(Input.GetKeyDown(KeyCode.R))
            Restart();
    }

    public void Restart()
    {
        TimeLimit.Instance.isFinish = false;
        CommandManager.Instance.isFinish = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadTitleScene()
    {
        difficult = Difficult.Loser;
        SceneManager.LoadScene("TitleScene");
    }
}