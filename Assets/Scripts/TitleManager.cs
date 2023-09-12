using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject difficultPanel;
    [SerializeField] private TextMeshProUGUI difficultText;
    private Difficult[] difficults = { Difficult.Loser, Difficult.Very_Easy, Difficult.Easy, Difficult.Normal, Difficult.Hard, Difficult.Very_Hard, Difficult.DeadLine };
    private int dificultInt = 0;
    public int modeInt { get; set; }
    [SerializeField] private AudioClip uiSound;
    [SerializeField] private AudioClip bgm;

    private void Start()
    {
        SoundManager.Instance.Play(bgm, Sound.BGM, 0.6f);
        Button[] buttons = FindObjectsOfType<Button>(true);
        modeInt = 0;
        foreach(Button btn in buttons)
        {
            btn.onClick.AddListener(UIClick);
        }
    }

    private void UIClick()
    {
        SoundManager.Instance.Play(uiSound, Sound.UI);
    }

    public void ActiveDifficultPanel()
    {
        difficultPanel.SetActive(true);
    }

    public void LeftArrow()
    {
        if (dificultInt == 0) dificultInt = difficults.Length - 1;
        else dificultInt--;

        GameManager.difficult = difficults[dificultInt];
        difficultText.SetText(TransKor());
    }

    public void RightArrow()
    {
        if (dificultInt >= difficults.Length - 1) dificultInt = 0;
        else dificultInt++;

        GameManager.difficult = difficults[dificultInt];
        difficultText.SetText(TransKor());
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game" + modeInt + "Scene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    private string TransKor()
    {
        string a = null;

        switch(GameManager.difficult)
        {
            case Difficult.Loser: 
                a = "����";
                break;
            case Difficult.Very_Easy:
                a = "���� ���׿�";
                break;
            case Difficult.Easy:
                a = "���׿�";
                break;
            case Difficult.Normal:
                a = "�Ҹ��ϳ׿�";
                break;
            case Difficult.Hard:
                a = "�� ��Ƴ׿�";
                break;
            case Difficult.Very_Hard:
                a = "�� ��Ƴ׿�";
                break;
            case Difficult.DeadLine:
                a = "�׾��";
                break;
        }

        return a;
    }
}
