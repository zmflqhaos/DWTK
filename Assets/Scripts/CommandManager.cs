using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Difficult : int
{
    Loser = 4,
    Very_Easy = 6,
    Easy = 9,
    Normal = 12,
    Hard = 15,
    Very_Hard = 18,
    DeadLine = 26
}

public class CommandManager : MonoSingleton<CommandManager>
{
    public List<Command> commands;
    public Command nextCommand;
    public Transform commandTrs;
    [SerializeField] private AudioClip inputSound;

    private KeyCode[] keyCodes = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Q, KeyCode.E, KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.R, KeyCode.F, KeyCode.V, KeyCode.T,
                                  KeyCode.G, KeyCode.B, KeyCode.Y, KeyCode.H, KeyCode.N, KeyCode.U, KeyCode.J, KeyCode.M, KeyCode.I, KeyCode.K, KeyCode.O, KeyCode.L, KeyCode.P};


    public bool isOpen;
    public bool isFinish;

    private int devPersent = -10;
    [SerializeField] TextMeshProUGUI devPersentTmp;

    private void Start()
    {
        Debug.Log(GameManager.difficult.ToString());
        MakeCommand((int)GameManager.difficult / 3 + 3);
        commandTrs.gameObject.SetActive(false);
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
            commandTrs.gameObject.SetActive(isOpen);
        }
        else
        {
            if (!isOpen) return;

            if (Input.anyKeyDown)
            {
                IsSuccess(nextCommand.InputKey());
                SoundManager.Instance.Play(inputSound, Sound.EFFECT);
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
        else MakeCommand((int)GameManager.difficult / 3 + 3);
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

    public KeyCode SendRandomKeyCode()
    {
        return keyCodes[Random.Range(0, (int)GameManager.difficult)];
    }
}
