using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameOverAnim gameOverAnim = null;

    public void GameOverStart()
    {
        gameOverAnim.PlayGameOverAnim();
    }
}
