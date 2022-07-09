using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ScoreManager : MonoBehaviour
{
    public static Action OnTaskComplete;
    public int countStrikes;
    private int allStrikes;
    private int bestStrikes;
    private int countPoint;
    private int bestPoint;
    private int countCompletedTask;
    private int timesGame;

    private void Start()
    {
        bestPoint = PlayerPrefs.GetInt("BEST_POINTS");
        bestStrikes = PlayerPrefs.GetInt("BEST_STRIKES");
        countCompletedTask = PlayerPrefs.GetInt("COMPLETED_TASK");
    }
    private void OnEnable()
    {
        BirdController.OnStartGame += AddTimeGame;
        BirdController.OnMissStrike += DeleteStrikes;
        BirdController.OnClearStrike += AddStrike;

        BirdController.OnDead += DeleteStrikes;
        BirdController.OnDead += DeletePoint;

        OnTaskComplete += DeleteStrikes;
        OnTaskComplete += DeletePoint;
        OnTaskComplete += AddCompletedTask;

        BirdController.OnJumped += AddPoint;
    }

    private void OnDisable()
    {
        BirdController.OnStartGame -= AddTimeGame;
        BirdController.OnMissStrike -= DeleteStrikes;
        BirdController.OnClearStrike -= AddStrike;

        BirdController.OnDead -= DeleteStrikes;
        BirdController.OnDead -= DeletePoint;
        BirdController.OnDead -= DeleteAllStrikes;


        OnTaskComplete -= DeleteStrikes;
        OnTaskComplete -= DeletePoint;
        OnTaskComplete -= AddCompletedTask;

        BirdController.OnJumped -= AddPoint;
    }
    public void NEWTASK()
    {
        OnTaskComplete?.Invoke();
    }
    private void DeleteAllStrikes()
    {
        allStrikes = 0;
    }
    private void DeleteStrikes()
    {
        countStrikes = 0;
    }
    private void DeletePoint()
    {
        countPoint = 0;
    }
    private void AddPoint()
    {
        countPoint++;

        if(countPoint > bestPoint)
        {
            bestPoint = countPoint;
            PlayerPrefs.SetInt("BEST_POINTS", bestPoint);
        }

        TaskPoint(countPoint);
    }
    private void AddStrike()
    {
        countStrikes++;
        allStrikes++;
        if(countStrikes > bestStrikes)
        {
            bestStrikes = countStrikes;
            PlayerPrefs.SetInt("BEST_STRIKES", bestStrikes);
        }


        TaskStrikes(countStrikes);
    }
    private void AddTimeGame()
    {
        timesGame++;
    }
    private void AddCompletedTask()
    {
        PlayerPrefs.SetInt("TASK6_POINTS", 0);
        countCompletedTask++;
        PlayerPrefs.SetInt("COMPLETED_TASK", countCompletedTask);
    }
    private void TaskStrikes(int strakes)
    {

        if(PlayerPrefs.GetInt("TASK") == 2)
        {
            if(strakes >= PlayerPrefs.GetInt("NUM_TASK"))
            {
                OnTaskComplete?.Invoke();
            }
        }   

        if(PlayerPrefs.GetInt("TASK") == 4)
        {
            if(allStrikes >= PlayerPrefs.GetInt("NUM_TASK"))
            {
                OnTaskComplete?.Invoke();
                allStrikes = 0;
            }
        }   

    }

    private void TaskPoint(int point)
    {

        if(PlayerPrefs.GetInt("TASK") == 0)
        {
            if(point >= PlayerPrefs.GetInt("NUM_TASK"))
            {
                OnTaskComplete?.Invoke();
            }
        }   

        if(PlayerPrefs.GetInt("TASK") == 1)
        {
            if(point >= PlayerPrefs.GetInt("NUM_TASK"))
            {
                OnTaskComplete?.Invoke();
            }
        }

        if(PlayerPrefs.GetInt("TASK") == 3)
        {
            if(point >= PlayerPrefs.GetInt("NUM_TASK") && countStrikes == 0)
            {
                OnTaskComplete?.Invoke();
            }
            if(countStrikes != 0)
            {
                DeletePoint();
                DeleteStrikes();
            }
        }   
        if(PlayerPrefs.GetInt("TASK") == 5)
        {
            int points3Game = PlayerPrefs.GetInt("TASK6_POINTS");
            points3Game += 1;
            PlayerPrefs.SetInt("TASK6_POINTS", points3Game);
            if(timesGame <= 3)
            {
                if(points3Game >= PlayerPrefs.GetInt("NUM_TASK"))
                {
                    OnTaskComplete?.Invoke();
                    points3Game = 0;
                    timesGame = 0;
                    PlayerPrefs.SetInt("TASK6_POINTS", points3Game);
                }
            }
            else
            {
                timesGame = 0;
                points3Game = 0;
                PlayerPrefs.SetInt("TASK6_POINTS", points3Game);
            }
        }   
    }
}
