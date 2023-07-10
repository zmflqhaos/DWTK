using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoSingleton<TimeLimit>
{
    public float timer;
    public float currentTimer;
    public bool isFinish;
    [SerializeField] private Image gage;

    private void Start()
    {
        currentTimer = timer;
    }

    private void Update()
    {
        if (isFinish) return;
        currentTimer -= Time.deltaTime;
        gage.fillAmount = currentTimer / timer;

        if (currentTimer <= 0) GameManager.Instance.GameOver();
    }
}
