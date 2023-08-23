using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BoardRandomText : MonoBehaviour
{
    [Tooltip("���� �ϴ�")]
    [SerializeField]
    private TextMeshPro randomText = null;

    [SerializeField]
    private List<string> titleList = new List<string>();
    [SerializeField]
    private List<string> nameList = new List<string>();

    [Tooltip("���� ����")]
    [SerializeField]
    private TextMeshPro randomContent = null;
    [SerializeField]
    private TextMeshPro randomContent2 = null;

    [SerializeField]
    private List<string> subjectList = new List<string>();
    [SerializeField]
    private List<string> mathContentList = new List<string>();
    [SerializeField]
    private List<string> koreanContentList = new List<string>();
    [SerializeField]
    private List<string> commonSoicalContentList = new List<string>();
    [SerializeField]
    private List<string> koreanHistoryContentList = new List<string>();
    [SerializeField]
    private List<string> physicsContentList = new List<string>();
    [SerializeField]
    private List<string> englishContentList = new List<string>();

    private Dictionary<string, List<string>> subjectContentDic = new Dictionary<string, List<string>>();
    private HashSet<int> selectNum = new HashSet<int>();

    private string subject = string.Empty;
    private string content = string.Empty;
    private string totalContent = string.Empty;

    private bool isContent1Set = false;

    private string title = string.Empty;
    private string name = string.Empty;

    private int contentCount = 0;

    private void Awake()
    {
        Init();
    }


    private void Init()
    {
        title = string.Empty;
        name = string.Empty;

        subject = string.Empty;
        content = string.Empty;

        selectNum.Clear();

        contentCount = 0;
        InitDic();
    }

    private void Start()
    {
        RandomText();
        SetSubjectContent();
    }

    public void InitDic()
    {
        subjectContentDic.Add("����", mathContentList);
        subjectContentDic.Add("����", koreanContentList);
        subjectContentDic.Add("���ջ�ȸ", commonSoicalContentList);
        subjectContentDic.Add("����", physicsContentList);
        subjectContentDic.Add("�ѱ���", koreanHistoryContentList);
        subjectContentDic.Add("����", englishContentList);
    }

    public void SetSubjectContent()
    {
        subject = subjectList[UnityEngine.Random.Range(0, subjectList.Count)];

        int rand = 0;

        while(contentCount < 5)
        {
            if(contentCount == 3 && !isContent1Set)
            {
                isContent1Set = true;
                totalContent = string.Format("{0}\n\n{1}", subject, content);
                randomContent.text = totalContent;
                content = string.Empty;
            }

            rand = UnityEngine.Random.Range(0, subjectContentDic[subject].Count);

            if (!selectNum.Contains(rand))
            {
                content += subjectContentDic[subject][rand];
                content += "\n\n";
                contentCount++;
                selectNum.Add(rand);
            }
        }

        totalContent = string.Format("{0}", content);
        randomContent2.text = totalContent;
    }

    private void RandomText()
    {
        if(titleList.Count == 0 || nameList.Count == 0)
        {
            Debug.LogError("Ÿ��Ʋ �Ǵ� �̸� ���� ����");
            return;
        }
        title = titleList[UnityEngine.Random.Range(0, titleList.Count)];
        name = nameList[UnityEngine.Random.Range(0,  nameList.Count)];

        randomText.text = string.Format("{0}\n\n<color=#808080>{1}</color>", title, name);
    }
}
