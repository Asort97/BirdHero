using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] spritesPart;
    private void Awake()
    {
        int id = PlayerPrefs.GetInt("CURRENT_SKIN");
        GetComponent<SpriteRenderer>().sprite = spritesPart[id];
    }


}
