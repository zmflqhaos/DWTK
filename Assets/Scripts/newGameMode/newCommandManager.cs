using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCommandManager : CommandManager
{
    private bool isBuging;
    private int point;
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
                if (Random.Range(1, 101) > 75)
                {
                    isBuging = true;
                    int rand = Random.Range(1, 5);

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
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    private void RandBug4()
    {
        commandTrs.transform.localScale = arrowTrs.localScale = new Vector3(0.5f, 0.5f, 1);
    }
}
