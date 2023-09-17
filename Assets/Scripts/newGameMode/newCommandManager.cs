using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class newCommandManager : CommandManager
{
    private bool isBuging;
    private int point;
    private int difficultValue;
    [SerializeField] private TextMeshProUGUI devPer;
    [SerializeField] private Transform arrowTrs;
    [SerializeField] private GameObject bugImage;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(BugCoru());
    }

    protected override void IsSuccess(bool input)
    {
        if(input)
        {
            nextCommand.transform.localScale = new Vector3(1, 1, 1);
        }
        base.IsSuccess(input);
    }

    protected override void Update()
    {
        InputCheck();
        arrowTrs.gameObject.SetActive(commandTrs.gameObject.activeSelf);
        BugFixCheck();
    }

    private void BugFixCheck()
    {
        if (!isBuging) return;

        if(point<devPersent)
        {
            isBuging = false;
            commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(1, 1, 1);
            bugImage.SetActive(false);
        }
    }

    private IEnumerator BugCoru()
    {
        while(true)
        {
            if (!isBuging)
            {
                devPer.color = Color.white;
                if (Random.Range(1, 101) > 70 - difficultValue)
                {
                    isBuging = true;
                    int rand = Random.Range(1, 6);

                    Invoke("RandBug" + rand, 0);
                    point = devPersent;
                }
            }
            else
            {
                devPer.color = Color.red;
                ChangeDevPersent(-1);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void RandBug1()
    {
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(1, -1, 1);
    }

    private void RandBug2()
    {
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(-1, 1, 1);
    }

    private void RandBug3()
    {
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(0.5f, 0.5f, 1);
    }

    private void RandBug4()
    {
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(-1, 1, 1);
    }

    private void RandBug5()
    {
        //무슨 버그를 넣을까
        bugImage.SetActive(true);
    }


    private void SetDifficultValue()
    {
        switch (GameManager.difficult)
        {
            case Difficult.Loser:
                difficultValue = -5;
                break;
            case Difficult.Very_Easy:
                difficultValue = 0;
                break;
            case Difficult.Easy:
                difficultValue = 3;
                break;
            case Difficult.Normal:
                difficultValue = 6;
                break;
            case Difficult.Hard:
                difficultValue = 9;
                break;
            case Difficult.Very_Hard:
                difficultValue = 12;
                break;
            case Difficult.DeadLine:
                difficultValue = 15;
                break;
        }
    }
}
