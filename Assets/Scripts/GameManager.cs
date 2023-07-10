using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    private bool isFinish;
    [SerializeField] GameObject gameClearPanel;
    [SerializeField] GameObject gameOverPanel;

    public void GameClear()
    {
        gameClearPanel.SetActive(true);
        isFinish = true;
        TimeLimit.Instance.isFinish = true;
        CommandManager.Instance.isFinish = true;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
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
        SceneManager.LoadScene("GameScene");
    }
}
