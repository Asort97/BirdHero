using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks: MonoBehaviour
{
    private int lastTask = -1;
    private int currentTask;
    private string titleTask;

    public void ChoosingTask()
    {
        currentTask = Random.Range(0, 6);
        
        if(lastTask == currentTask)
        {
            currentTask = Random.Range(0, 6);
        }

        else
        {
            PlayerPrefs.SetInt("TASK", currentTask);
            switch (currentTask)
            {
                case 0:
                    Task1();
                    break;
                case 1:
                    Task2();
                    break;
                case 2:
                    Task3();
                    break;
                case 3:
                    Task4();
                    break;
                case 4:
                    Task5();
                    break;
                case 5:
                    Task6();
                    break;
            }
        }
    }   
    private void Task1() // Набрать х очков
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((10 + 50 * x) * Random.Range(0.8f , 1.1f));

        titleTask = "Score " + value + " points";

        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);

    }
    private void Task2() // набрать ровно 
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((8 + 40 * x) * Random.Range(0.8f , 1.1f));
        titleTask = "Score exactly " + value + " points";
        
        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);

    }
    private void Task3() // Набрать стрик x
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((2 + 3 * x) * Random.Range(0.8f , 1.1f));

        titleTask = "Score strakes " + value + " points";
        
        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);
    }
    private void Task4() // набрать х подряд без идеальных попаданий
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((2 + 3 * x) * Random.Range(0.8f , 1.1f));

        titleTask = "Score " + value + " in a row";
        
        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);
    }
    private void Task5() // набрать х идеальных за одну игру
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((5 + 10 * x) * Random.Range(0.8f , 1.1f));

        titleTask = "Score " + value + " perfect points in one game";
        
        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);
    }
    private void Task6() // сыграть 3 игры набрав не менее х
    {
        float x = (PlayerPrefs.GetInt("GAME_LEVEL", 1) - 1) * 0.01f;
        float value = Mathf.Round((10 + 30 * x) * Random.Range(0.8f , 1.1f));

        titleTask = "play 3 games by score at least " + value + " points";
        
        PlayerPrefs.SetString("TITLE_TASK", titleTask);
        PlayerPrefs.SetInt("NUM_TASK", (int)value);
    }
}
