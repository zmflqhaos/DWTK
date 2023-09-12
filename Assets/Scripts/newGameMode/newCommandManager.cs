using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCommandManager : CommandManager
{
    private bool isBuging;
    private int point;
    private int difficultValue;
    [SerializeField] private Transform arrowTrs;

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
        }
    }

    private IEnumerator BugCoru()
    {
        while(true)
        {
            if (!isBuging)
            {
                if (Random.Range(1, 101) > 70 - difficultValue)
                {
                    isBuging = true;
                    int rand = Random.Range(1, 4);

                    Invoke("RandBug" + rand, 0);
                    point = devPersent;
                }
            }
            else
            {
                ChangeDevPersent(-2);
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
                difficultValue = 5;
                break;
            case Difficult.Normal:
                difficultValue = 10;
                break;
            case Difficult.Hard:
                difficultValue = 15;
                break;
            case Difficult.Very_Hard:
                difficultValue = 20;
                break;
            case Difficult.DeadLine:
                difficultValue = 25;
                break;
        }
    }
}
