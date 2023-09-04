using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChange : MonoBehaviour
{
    [SerializeField] private ModeCommand[] commands;
    [SerializeField] private TitleManager titleManager;
    [SerializeField] private KeyCode[] input = new KeyCode[10];

    [SerializeField] private GameObject[] modePanel;

    private int witch = 0;
    private int i = 0;

    private void Update()
    {
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
            witch++;
            if (Input.GetKeyDown(commands[i].command[witch-1]))
            {
                input[witch-1] = commands[i].command[witch-1];
            }
            int point = 0;
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
    }
}
