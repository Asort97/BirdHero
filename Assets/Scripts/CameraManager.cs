using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private float speedMove = 1f;
    [SerializeField] private BirdController playerTarget;

    private void OnEnable()
    {
        BirdController.OnPlace += MoveCamera;
        BirdController.OnDead += CameraShake;
    }
    private void OnDisable()
    {
        BirdController.OnPlace -= MoveCamera;
        BirdController.OnDead -= CameraShake;
    }
    private void MoveCamera()
    {
        transform.DOLocalMove(new Vector3(playerTarget.lastTarget.position.x,
                                     playerTarget.lastTarget.position.y + 3.6f
                                    , -10f), speedMove);
    }
    private void CameraShake()
    {
        transform.DOShakePosition(0.5f, 1, 10, 90, false, true).OnComplete(
            () => transform.DOLocalMoveY(0f, 0.2f)
        );
    }
}
