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
        //여기에 랜덤하게 키 배정해주는 코드

        key = keyCodes[Random.Range(0, 4)];
    }

    public bool InputKey()
    {
        Debug.Log("힝");
        bool returnValue = false;
        if(Input.GetKey(key))
        {
            returnValue = true;
        }
        return returnValue;
    }
}
