using UnityEngine;
using DG.Tweening;

public class MenuAnimations : MonoBehaviour
{
    [SerializeField] private Transform[] stageAnims;
    [SerializeField] private Animator arrowR;
    [SerializeField] private Animator arrowL;
    [SerializeField] private Animator title;

    public void StartAnim()
    {
        stageAnims[0].DOLocalMoveY(-950, 0.3f).OnComplete(
        ()=> stageAnims[1].DOLocalMoveY(47, 0.2f).OnComplete(
        ()=> ArrowAnim() ));
    }
    private void ArrowAnim()
    {
        arrowR.SetTrigger("Start");
        arrowL.SetTrigger("Start");
        Invoke("TitleAlpha", 0.2f);
    }
    private void TitleAlpha()
    {
        title.SetTrigger("Start");
    }
}
