using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatisticManager : MonoBehaviour
{
    [SerializeField] private TMP_Text strikesText;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private TMP_Text gamesText;
    [SerializeField] private TMP_Text birdsText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text highScoreStrikesText;


    private int allStrikes;
    private int allPoints;
    private int allGames;
    private int allBirds;
    private int highScore;
    private int highScoreStrikes;
    
    private void Start()
    {
        allPoints = PlayerPrefs.GetInt("POINTS");
        allStrikes = PlayerPrefs.GetInt("STRIKES");
        allGames = PlayerPrefs.GetInt("GAMES");
        allBirds = PlayerPrefs.GetInt("BIRDS");
        highScore = PlayerPrefs.GetInt("BEST_POINTS");
        highScoreStrikes = PlayerPrefs.GetInt("BEST_STRIKES");

        strikesText.text = allStrikes.ToString();
        pointsText.text = allPoints.ToString();
        gamesText.text = allGames.ToString();
        birdsText.text = allBirds.ToString();
        highScoreText.text = highScore.ToString();
        highScoreStrikesText.text = highScoreStrikes.ToString();

    }

    private void OnEnable()
    {
        BirdController.OnClearStrike += AddStrikes;
        BirdController.OnJumped += AddPoint;
        BirdController.OnStartGame += AddTimeGame;
        NewBird.OnNewBird += AddBird;
    }
    private void OnDisable()
    {
        BirdController.OnClearStrike -= AddStrikes;
        BirdController.OnJumped -= AddPoint;  
        BirdController.OnStartGame -= AddTimeGame;
        NewBird.OnNewBird -= AddBird;
    }
    private void AddPoint()
    {
        allPoints++;
        PlayerPrefs.SetInt("POINTS",allPoints);
    }
    private void AddStrikes()
    {
        allStrikes++;
        PlayerPrefs.SetInt("STRIKES", allPoints);
    }
    private void AddBird()
    {
        allBirds++;
        PlayerPrefs.SetInt("BIRDS", allBirds);
    }
    private void AddTimeGame()
    {
        allGames++;
        PlayerPrefs.SetInt("GAMES", allGames);
    }
}
