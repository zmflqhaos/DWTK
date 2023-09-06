using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    [SerializeField]
    private GameObject btns = null;

    [SerializeField]
    private int shakeTime = 8;
    private Vector3 initPos;
    private Vector3 pos;
    private Vector3 randomPos;

    [SerializeField]
    private float radius = 3f;

    [SerializeField]
    private float waitSec = 0.2f;
    private WaitForSeconds waitForSec;

    private RectTransform rectTransform = null;

    private Animator anim = null;

    private void Awake()
    {
        initPos = transform.position;
        rectTransform = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        waitForSec = new WaitForSeconds(waitSec);

        gameObject.SetActive(false);
    }

    public void PlayGameOverAnim()
    {
        ToggleBtnInGameOverPanel();

        gameObject.SetActive(true);
        rectTransform.position = initPos;
        anim.SetTrigger("GameOverTrigger");
    }

    public void ShakeObj()
    {
        StartCoroutine(IEShakeObj());
    }

    public IEnumerator IEShakeObj()
    {
        rectTransform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        pos = rectTransform.position;
        for (int i = 0; i < shakeTime; ++i)
        {
            randomPos = Random.insideUnitCircle * radius;
            rectTransform.position = pos + randomPos;
            yield return waitForSec;
        }
        gameObject.SetActive(false);
        anim.SetTrigger("Idle");

        ToggleBtnInGameOverPanel();
    }

    public void ToggleBtnInGameOverPanel()
    {
        btns.SetActive(!btns.activeSelf);
    }
}
