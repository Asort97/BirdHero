using UnityEngine;
using DG.Tweening;
public class TransiitionEffect : MonoBehaviour
{
    [SerializeField] private Transform upPart;
    [SerializeField] private Transform bottomPart;
    [SerializeField] private MenuAnimations menuAnims;
    private void Start()
    {
        Unfade();
    }

    public void Fade()
    {
        upPart.DOLocalMoveY(-5, 0.2f);
        bottomPart.DOLocalMoveY(5,0.2f);
    }
    public void Unfade()
    {
        upPart.DOLocalMoveY(0, 0.2f);
        bottomPart.DOLocalMoveY(0, 0.2f).OnComplete(() => menuAnims.StartAnim());
    }

}
