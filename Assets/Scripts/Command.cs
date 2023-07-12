using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Command : PoolObject
{
    [SerializeField]
    private KeyCode key;
    private bool isSetted;
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        if (isSetted) return;
        isSetted = true;
        key = CommandManager.Instance.SendRandomKeyCode();
        text.SetText(key.ToString());
    }

    public bool InputKey()
    {
        bool returnValue = false;
        if(Input.GetKey(key))
        {
            returnValue = true;
        }
        return returnValue;
    }

    public override void Pooling()
    {
        isSetted = false;
        base.Pooling();
    }
}
