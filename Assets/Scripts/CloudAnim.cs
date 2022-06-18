using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnim : MonoBehaviour
{
    [SerializeField] private float speedAnim;
    private void Update()
    {
        transform.eulerAngles += new Vector3(0,0, Time.deltaTime * speedAnim);
    }
}
