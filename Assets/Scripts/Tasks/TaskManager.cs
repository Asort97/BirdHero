using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;
public class TaskManager : MonoBehaviour
{
    [SerializeField] private GameObject taskPanel;
    [SerializeField] private TMP_Text titleTask;
    [SerializeField] private TMP_Text levelTask;
    [SerializeField] private Tasks tasks;
    private bool isFaded = true;
    private int haveTask;
    private int currentLevel;
    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("GAME_LEVEL", 1);
        ChoseTask();
        FadeButton();
    }
    private void OnEnable()
    {
        ScoreManager.OnTaskComplete += TaskComplete;
    }
    private void OnDisable()
    {
        ScoreManager.OnTaskComplete -= TaskComplete;
    }
    private void ChoseTask()
    {
        haveTask = PlayerPrefs.GetInt("HAVE_TASK");
        if(haveTask == 0)
        {  
            tasks.ChoosingTask();

            haveTask = 1;
            PlayerPrefs.SetInt("HAVE_TASK", haveTask);            
        }
        SetTitlePanel();        
    }
    private void SetTitlePanel()
    {
        levelTask.text = "#" + PlayerPrefs.GetInt("GAME_LEVEL", 1);
        titleTask.text = PlayerPrefs.GetString("TITLE_TASK");
    }

    public void FadeOnClick()
    {
        if(taskPanel.GetComponent<CanvasGroup>().alpha == 1)
            taskPanel.GetComponent<CanvasGroup>().DOFade(0, 2);
    }
    public void FadeButton()
    {  
        if(taskPanel.GetComponent<CanvasGroup>().alpha == 0)
        {
            taskPanel.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        }
        else
        {
            taskPanel.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        }
    }

    public void TaskComplete()
    {
        haveTask = 0;
        currentLevel++;
        PlayerPrefs.SetInt("GAME_LEVEL", currentLevel);
        PlayerPrefs.SetInt("HAVE_TASK", haveTask);

        taskPanel.GetComponent<CanvasGroup>().DOFade(1, 2).OnComplete(
            () => taskPanel.GetComponent<CanvasGroup>().DOFade(0, 0.3f)
        );

        FadeButton();
        ChoseTask();
    }
}
