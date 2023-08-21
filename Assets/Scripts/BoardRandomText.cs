using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BoardRandomText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro randomText = null;

    [SerializeField]
    private List<string> titleList = new List<string>();
    [SerializeField]
    private List<string> nameList = new List<string>();

    private string title = string.Empty;
    private string name = string.Empty;

    private void Start()
    {
        title = string.Empty;
        name = string.Empty;

        RandomText();
    }

    private void RandomText()
    {
        if(titleList.Count == 0 || nameList.Count == 0)
        {
            Debug.LogError("타이틀 또는 이름 개수 부족");
            return;
        }
        title = titleList[UnityEngine.Random.Range(0, titleList.Count)];
        name = nameList[UnityEngine.Random.Range(0,  nameList.Count)];

        randomText.text = string.Format("{0}\n\n<color=#808080>{1}</color>", title, name);
    }
}
