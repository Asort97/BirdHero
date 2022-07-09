using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NewBird : MonoBehaviour
{
    public static Action OnNewBird;
    private int countCompletedTask;
    private int lastTask;
    private int giveBird;
    private void Start()
    {
        countCompletedTask = PlayerPrefs.GetInt("COMPLETED_TASK");
        lastTask = PlayerPrefs.GetInt("LAST_TASK");
        giveBird = PlayerPrefs.GetInt("GIVE_BIRD");
        Debug.Log(countCompletedTask);
        CheckCount();
        GiveBird();
    }

    private void OnEnable()
    {
        ScoreManager.OnTaskComplete += CheckCount;
    }
    private void OnDisable()
    {
        ScoreManager.OnTaskComplete -= CheckCount;
    }
    private void GiveBird()
    {
        if(giveBird == 1)
        {
            OnNewBird?.Invoke();
            giveBird = 0;
            PlayerPrefs.SetInt("GIVE_BIRD", giveBird);
        }
    }
    private void CheckCount()
    {
        if(PlayerPrefs.GetInt("GAME_LEVEL") % 10 == 0 && PlayerPrefs.GetInt("GAME_LEVEL") != lastTask)
        {
            lastTask = PlayerPrefs.GetInt("GAME_LEVEL");
            PlayerPrefs.SetInt("LAST_TASK", lastTask);
            giveBird = 1;
            PlayerPrefs.SetInt("GIVE_BIRD", giveBird);
        }
    }
        
}
