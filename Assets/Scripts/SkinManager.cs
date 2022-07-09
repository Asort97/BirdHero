using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] eggSkins;
    [SerializeField] private GameObject FadeBg;
    private int allBirds;
    private void OnEnable()
    {
        NewBird.OnNewBird += SpawnEgg;
        EggBird.OnOpenEgg += DisableFog;
    }
    private void OnDisable()
    {
        NewBird.OnNewBird -= SpawnEgg;
        EggBird.OnOpenEgg -= DisableFog;
    }
    private void DisableFog()
    {
        FadeBg.SetActive(false);
    }
    private void SpawnEgg()
    {
        FadeBg.SetActive(true);
        allBirds = PlayerPrefs.GetInt("BIRDS");
        allBirds++;
        PlayerPrefs.SetInt("BIRDS", allBirds);
        Instantiate(eggSkins[Random.Range(0, eggSkins.Length)], Vector3.zero, Quaternion.identity);
    }

}
