using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Command : PoolObject
{
    [SerializeField]
    private KeyCode key;
    private KeyCode[] keyCodes = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
    private bool isSetted;
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        if (isSetted) return;
        isSetted = true;
        key = keyCodes[Random.Range(0, 4)];
        text.SetText(key.ToString());
    }

    public bool InputKey()
    {
        Debug.Log("Èþ");
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
