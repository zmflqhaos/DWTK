using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private bool isBack = false;
    public bool IsBack { get { return isBack; } }
    private int rand;
    private Animator animator;

    private int difficultValue = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TeacherCoru());
        SetDifficultValue();
    }


    private IEnumerator TeacherCoru()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            rand = Random.Range(0, 100);

            if (isBack)
            {
                if (rand > 30 + difficultValue) animator.SetTrigger("TurnFront");
            }
            else
            {
                if (rand > 80 - difficultValue) animator.SetTrigger("TurnBack");
            }
        }
    }

    public void ToggleIsBack()
    {
        isBack = !isBack;
    }

    private void SetDifficultValue()
    {
        switch(GameManager.difficult)
        {
            case Difficult.Loser:
                difficultValue = 0;
                break;
            case Difficult.Very_Easy:
                difficultValue = 2;
                break;
            case Difficult.Easy:
                difficultValue = 5;
                break;
            case Difficult.Normal:
                difficultValue = 8;
                break;
            case Difficult.Hard:
                difficultValue = 11;
                break;
            case Difficult.Very_Hard:
                difficultValue = 13;
                break;
            case Difficult.DeadLine:
                difficultValue = 15;
                break;
        }
    }
}
