using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class EggBird : MonoBehaviour
{
    public static Action OnOpenEgg;
    [SerializeField] private float forceShake;
    [SerializeField] private float durationShake;

    [SerializeField] private int skinId;
    [SerializeField] private GameObject[] statesEgg;
    [SerializeField] private GameObject currentBird;
    [SerializeField] private GameObject confettiBurst;
    private int isOpen;
    private int stateId;
    private bool canClose;

    private void OnMouseDown()
    {   

        stateId = Mathf.Clamp(stateId + 1, 0, 3);

        if(!canClose)
        {
            statesEgg[stateId].SetActive(true);
            transform.DOShakePosition(forceShake , durationShake, 10, 90, false, false);
        }

        isOpen = 1;
        PlayerPrefs.SetInt("SKIN_" + skinId, isOpen);

        if(stateId == 3 && !canClose)
        {
            DisableEgg();
            Instantiate(confettiBurst, Vector3.zero, Quaternion.identity, transform);
            currentBird.SetActive(true);
            currentBird.transform.DOScale(new Vector3(0.45f, 0.45f, 0.45f), 0.4f);
            canClose = true;

        }                     
        if(canClose)
        {
            Destroy(gameObject, 4);
        }
    }
    private void DisableEgg()
    {
        foreach (GameObject state in statesEgg)
        {
            state.SetActive(false);
        }
    }
}
