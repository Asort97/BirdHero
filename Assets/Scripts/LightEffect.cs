using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    [SerializeField] private GameObject[] lightEffects;
    [SerializeField] private float[] speedEffects;
    private void Update()
    {
        lightEffects[0].transform.Rotate(new Vector3(0, 0, 1), speedEffects[0] * Time.deltaTime);
        lightEffects[1].transform.Rotate(new Vector3(0, 0, 1), speedEffects[1] * Time.deltaTime);
        lightEffects[2].transform.Rotate(new Vector3(0, 0, 1), speedEffects[2] * Time.deltaTime);
    }
}
