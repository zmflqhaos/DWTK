using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear : MonoBehaviour
{
    [SerializeField]
    private GameObject gameClearBtnAndText = null;
    [SerializeField]
    private GameObject gameClearSceneAnim = null;
    [SerializeField]
    private TextMeshProUGUI hintText;

    private void Awake()
    {
        gameClearBtnAndText.SetActive(false);
    }

    public void GameClearStart()
    {
        StartCoroutine(PlayGameClearAnim());
    }

    public IEnumerator PlayGameClearAnim()
    {
        gameClearSceneAnim.SetActive(true);
        yield return new WaitForSeconds(2f);
        gameClearSceneAnim.SetActive(false);

        ToggleBtnInGameOverPanel();
    }

    public void ToggleBtnInGameOverPanel()
    {
        gameClearBtnAndText.SetActive(!gameClearBtnAndText.activeSelf);

        if (hintText == null) return;

        switch (GameManager.difficult)
        {
            case Difficult.Loser:
                hintText.SetText("<-");
                break;
            case Difficult.Very_Easy:
                hintText.SetText("<-, ->");
                break;
            case Difficult.Easy:
                hintText.SetText("<-, ->, A");
                break;
            case Difficult.Normal:
                hintText.SetText("<-, ->, A, B");
                break;
            case Difficult.Hard:
                hintText.SetText("<-, ->, A, B, Enter");
                break;
            case Difficult.Very_Hard:
                hintText.SetText("Title - <-, ->, A, B, Enter");
                break;
            case Difficult.DeadLine:
                hintText.SetText("Title - <-, ->, A, B, Enter");
                break;
        }
    }
}
