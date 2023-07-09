using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoSingleton<CommandManager>
{
    public List<Command> commands;
    public Command nextCommand;
    public Transform commandTrs;

    public bool isOpen;

    [SerializeField] private int defficult;

    private void Start()
    {
        MakeCommand(defficult);
    }

    public void MakeCommand(int summonCommand)
    {
        for(int i=0; i<summonCommand; i++)
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
        if(Input.GetKey(KeyCode.Return))
        {
            isOpen = !isOpen;
        }
        else
        {
            if (!isOpen) return;

            if (Input.anyKey)
            {
                nextCommand.InputKey();
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
}
