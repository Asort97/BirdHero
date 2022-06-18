using UnityEngine;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{
    public void OnButton(Transform button)
    {
        button.DOPunchScale(transform.localScale / -3f, 0.2f);
    }
}
