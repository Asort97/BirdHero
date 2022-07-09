using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class LevelGenerator : MonoBehaviour
{
    public static Action<Transform> OnCreateTarget;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform startSpawnPoint;

    [SerializeField] private float minScalePoint = 1.1f;
    [SerializeField] private float maxScalePoint = 3f;
    [SerializeField] private Transform player;
    private GameObject currentTarget;
    private void Awake()
    {
        GenerateStart();
    }
    private void OnEnable()
    {
        BirdController.OnJumped += GenerateNext;
        BirdController.OnDead += GenerateStart;
    }
    private void OnDisable()
    {
        BirdController.OnJumped -= GenerateNext;
        BirdController.OnDead -= GenerateStart;
    }

    public void GenerateStart()
    {
        Destroy(currentTarget);
        Vector3 point = new Vector3(UnityEngine.Random.Range(-1.3f, 1.3f), 
                                    UnityEngine.Random.Range(startSpawnPoint.position.y - 3f, startSpawnPoint.position.y),
                                    0);

        GameObject circle = Instantiate(circlePrefab, point, Quaternion.identity, null);

        circle.GetComponentInChildren<TMP_Text>().text = (scoreManager.countStrikes + 1).ToString();

        float valueOut = UnityEngine.Random.Range(minScalePoint, maxScalePoint);
        float valueIn = UnityEngine.Random.Range(valueOut / 1.8f, valueOut / 1.5f);


        circle.GetComponent<Point>().outCircle.transform.localScale = new Vector2(valueOut,
                                                  valueOut);
        circle.GetComponent<Point>().innerCircle.transform.localScale = new Vector2(valueIn,
                                                  valueIn);         
        currentTarget = circle;
        OnCreateTarget.Invoke(circle.transform);
    }

    public void GenerateNext()
    {
        
        Vector3 point = new Vector3(UnityEngine.Random.Range(-1.2f, 1.2f), 
                                    UnityEngine.Random.Range(currentTarget.transform.position.y + 4f, currentTarget.transform.position.y + 6f),
                                    0);

        GameObject circle = Instantiate(circlePrefab, point, Quaternion.identity, null);

        circle.GetComponentInChildren<TMP_Text>().text = (scoreManager.countStrikes + 1).ToString();

        float valueOut = UnityEngine.Random.Range(minScalePoint, maxScalePoint);
        float valueIn = UnityEngine.Random.Range(valueOut / 1.8f, valueOut / 1.5f);

        circle.GetComponent<Point>().outCircle.transform.localScale = new Vector2(valueOut,
                                                  valueOut);
        circle.GetComponent<Point>().innerCircle.transform.localScale = new Vector2(valueIn,
                                                  valueIn);                                      
        currentTarget = circle;
        OnCreateTarget.Invoke(circle.transform);
    }
}
 