using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private GameObject spriteSkin;
    public int skinID;
    public int isOpen;
    private void Awake()
    {
        if(skinID != 0)
        {
            isOpen = PlayerPrefs.GetInt("SKIN_" + skinID);
            if(isOpen == 1)
            {
                spriteSkin.SetActive(true);
                GetComponent<Image>().color = new Color(0,0,0,0);
            }


        }

    }   

}
