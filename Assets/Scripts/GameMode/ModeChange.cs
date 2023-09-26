using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    [SerializeField] private ModeCommand[] commands;
    [SerializeField] private TitleManager titleManager;
    [SerializeField] private KeyCode[] input = new KeyCode[10];

    [SerializeField] private GameObject[] modePanel;
    [SerializeField] private AudioClip[] mode2Bgm;

    private int witch = 0;
    private int i = 0;

    private void Update()
    {
        if (i >= commands.Length) i--;

        if(Input.GetKeyDown(KeyCode.Return))
        {
            AnswerCheck();
        }
        else if(Input.anyKeyDown)
        {
            FindCommand();
        }
    }

    private void FindCommand()
    {
        if (input[0]==KeyCode.None)
        {
            for (i = 0; i < commands.Length; i++)
            {
                if (Input.GetKeyDown(commands[i].command[0]))
                {
                    input[0] = commands[i].command[0];
                    witch++;
                    break;
                }
            }
        }
        else
        {
            int point = 0;
            witch++;
            if(commands[i].command.Length<witch)
            {
                input = new KeyCode[10];
                witch = 0;
                return;
            }
            if (Input.GetKeyDown(commands[i].command[witch-1]))
            {
                input[witch-1] = commands[i].command[witch-1];
            }
            for (int j = 0; j < witch; j++)
            {
                if (input[j] == commands[i].command[j])
                {
                    point++;
                }
            }
            if (point != witch) 
            {
                input = new KeyCode[10];
                witch = 0;
            }
        }


    }

    private void AnswerCheck()
    {
        if (commands[i].SameCheck(input))
        {
            input = new KeyCode[10];
            witch = 0;
            Invoke("Mode" + i, 0);
        }
    }

    private void Mode0()
    {
        Debug.Log("모드 0 작동");
        titleManager.modeInt = 1;
        modePanel[0].SetActive(true);
    }

    private void Mode1()
    {
        Debug.Log("모드 1 작동");
        titleManager.modeInt = 2;
        modePanel[1].SetActive(true);
        int a = Random.Range(0, mode2Bgm.Length);
        float volume = 0;
        switch(a)
        {
            case 0: volume = 1; break;
            case 1: volume = 0.4f; break;
            case 2: volume = 0.1f; break;
        }
        SoundManager.Instance.Play(mode2Bgm[a], Sound.BGM, volume);
    }
}
