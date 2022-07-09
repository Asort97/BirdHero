using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFade : MonoBehaviour
{
    private bool isEnabled = true;
    public void OnButtonFade(Transform button)
    {
        isEnabled = !isEnabled;
        button.GetComponent<CanvasGroup>().alpha = isEnabled ? 1f : 0.6f;
  

    }
}
