using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newCommandManager : CommandManager
{
    protected override void Update()
    {
        InputCheck();
    }
}
