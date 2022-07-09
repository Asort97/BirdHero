using UnityEngine;
using DG.Tweening;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform pauseButton;
    [SerializeField] private GameObject openButton;
    [SerializeField] private GameObject closeButton;
    [SerializeField] private GameObject fadeBg;
    [SerializeField] private TaskManager taskManager;
    private bool pauseOpened;
    public void OnButton(Transform button)
    {
        button.DOPunchScale(transform.localScale / -3f, 0.2f);
    }
    private void Start()
    {
        if(player)
        {
            player.DOLocalMoveY(-3.5f, 0.2f);
            pauseButton.DOLocalMoveY(1450f, 0.2f);
        }
    }
    public void OpenPausePanel()
    {
        if(!pauseOpened)
        {
            pauseButton.DOLocalMoveY(745f, 0.2f);
            pauseOpened = true;
        }
        else
        {
            pauseButton.DOLocalMoveY(1450f, 0.2f);
            pauseOpened = false;
        }
        openButton.SetActive(!openButton.activeSelf);
        closeButton.SetActive(!closeButton.activeSelf);        
    }
    public void OpenPanel(RectTransform panel)
    {
        fadeBg.SetActive(true);
        panel.DOAnchorPosY(60f, 0.3f).OnComplete(
            () => panel.DOAnchorPosY(-60f, 0.2f) 
        );
    }
    public void ClosePanel(RectTransform panel)
    {
        fadeBg.SetActive(false);
        panel.DOAnchorPosY(-2000f, 0.2f);
    }
}
