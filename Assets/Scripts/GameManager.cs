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
    [SerializeField] AudioClip bgm;

    private bool isGameOver = false;
    private GameOver gameOver = null;

    private void Start()
    {
        gameOver = gameOverPanel.GetComponent<GameOver>();
        SoundManager.Instance.Play(bgm, Sound.BGM);
    }

    public void GameClear()
    {
        gameClearPanel.SetActive(true);
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
;