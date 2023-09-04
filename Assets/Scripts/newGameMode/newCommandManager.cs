using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCommandManager : CommandManager
{
    private bool isBuging;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(BugCoru());
    }

    protected override void Update()
    {
        InputCheck();
    }

    private IEnumerator BugCoru()
    {
        while(true)
        {
            if (!isBuging)
            {
                if (Random.Range(1, 101) > 80)
                {
                    isBuging = true;
                    int rand = Random.Range(1, 4);

                    StartCoroutine("RandBug" + rand);
                }
            }
            else
            {
                ChangeDevPersent(-1);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator RandBug1()
    {
        commandTrs.transform.localScale = new Vector3(1, -1, 1);

        yield return new WaitForSeconds(3f);

        commandTrs.transform.localScale = new Vector3(1, 1, 1);
        isBuging = false;
    }

    private IEnumerator RandBug2()
    {
        commandTrs.transform.localScale = new Vector3(-1, -1, 1);

        yield return new WaitForSeconds(3f);

        commandTrs.transform.localScale = new Vector3(1, 1, 1);
        isBuging = false;
    }

    private IEnumerator RandBug3()
    {
        float rand = Random.Range(0.6f, 1.5f);
        commandTrs.transform.localScale = new Vector3(rand, rand, 1);

        yield return new WaitForSeconds(3f);

        commandTrs.transform.localScale = new Vector3(1, 1, 1);
        isBuging = false;
    }
}
