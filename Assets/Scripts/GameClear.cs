using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField]
    private GameObject gameClearBtnAndText = null;
    [SerializeField]
    private GameObject gameClearSceneAnim = null;
    [SerializeField]
    private GameObject gameClearPlayer = null;

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
    }
}
