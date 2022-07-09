using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingSkin : MonoBehaviour
{
    private int currentSkin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Skin>().isOpen == 1 || other.GetComponent<Skin>().skinID == 0 )
        {
            currentSkin = other.GetComponent<Skin>().skinID;
            PlayerPrefs.SetInt("CURRENT_SKIN", currentSkin);
            Debug.Log(currentSkin);
        }
    }
}
