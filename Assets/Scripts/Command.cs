using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : PoolObject
{
    [SerializeField]
    private KeyCode key;
    private KeyCode[] keyCodes = {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };

    private void OnEnable()
    {
        //���⿡ �����ϰ� Ű �������ִ� �ڵ�

        key = keyCodes[Random.Range(0, 4)];
    }

    public bool InputKey()
    {
        Debug.Log("��");
        bool returnValue = false;
        if(Input.GetKey(key))
        {
            returnValue = true;
        }
        return returnValue;
    }
}
