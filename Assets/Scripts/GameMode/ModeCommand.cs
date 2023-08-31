using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ModeCommand", menuName = "SO/ModeCommand")]
public class ModeCommand : ScriptableObject
{
    public KeyCode[] command;

    public bool SameCheck(KeyCode[] input)
    {
        bool same = true;
        for(int i=0; i<command.Length; i++)
        {
            if (command[i] != input[i]) same = false;
        }

        return same;
    }
}
