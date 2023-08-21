using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private bool isBack = false;
    public bool IsBack { get { return isBack; } }
    private int rand;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TeacherCoru());
    }


    private IEnumerator TeacherCoru()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);

            rand = Random.Range(0, 100);

            if (isBack)
            {
                if (rand > 40) animator.SetTrigger("TurnFront");
            }
            else
            {
                if (rand > 80) animator.SetTrigger("TurnBack");
            }
        }
    }

    public void ToggleIsBack()
    {
        isBack = !isBack;
    }
}
