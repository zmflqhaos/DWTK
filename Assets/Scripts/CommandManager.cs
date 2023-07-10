using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CommandManager : MonoSingleton<CommandManager>
{
    public List<Command> commands;
    public Command nextCommand;
    public Transform commandTrs;

    public bool isOpen;
    public bool isFinish;

    [SerializeField] private int defficult;
    [SerializeField] GameObject commandTrsObj;

    private int devPersent = -10;
    [SerializeField] TextMeshProUGUI devPersentTmp;

    private void Start()
    {
        MakeCommand(defficult);
        commandTrsObj.SetActive(false);
    }

    public void MakeCommand(int summonCommand)
    {
        ChangeDevPersent(10);
        for (int i=0; i<summonCommand; i++)
        {
            Command command = PoolManager.Instance.GetPoolObject("Command").GetComponent<Command>();
            command.transform.SetParent(commandTrs);
            commands.Add(command);
        }
        SetNextCommand();
    }

    private void Update()
    {
        InputCheck();
    }

    private void InputCheck()
    {
        if (isFinish) return;
        if(Input.GetKeyDown(KeyCode.Return))
        {
            isOpen = !isOpen;
            commandTrsObj.SetActive(isOpen);
        }
        else
        {
            if (!isOpen) return;

            if (Input.anyKeyDown)
            {
               IsSuccess(nextCommand.InputKey());
            }
        }
    }

    private void SetNextCommand()
    {
        if (commands.Count > 0)
        {
            nextCommand = commands[0];
            commands.RemoveAt(0);
        }
        else MakeCommand(defficult);
    }

    private void IsSuccess(bool input)
    {
        if(input)
        {
            nextCommand.Pooling();
            SetNextCommand();
        }
        else
        {
            ChangeDevPersent(-2);
        }
    }

    private void ChangeDevPersent(int value)
    {
        devPersent = Mathf.Clamp(devPersent += value, -100, 100);
        devPersentTmp.SetText(devPersent + " %");

        if(devPersent>=100)
        {
            GameManager.Instance.GameClear();
        }
        if(devPersent<=-100)
        {
            GameManager.Instance.GameOver();
        }
    }
}
