using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BirdController : MonoBehaviour
{
    public static Action OnStartGame;
    public static Action OnMissStrike;
    public static Action OnPlace;
    public static Action OnClearStrike;
    public static Action OnJumped;
    public static Action OnDead;

    [SerializeField] private float speedOpenWings = 0.15f;
    [SerializeField] private float speedMove;
    [SerializeField] private Transform wingR;
    [SerializeField] private Transform wingL;
    [SerializeField] private Transform birdBody;
    [SerializeField] private GameObject clickBtn;
    
    public Transform lastTarget;
    public Transform currentTarget;

    private Rigidbody2D rb;
    private Vector3 startScale;
    private Vector3 direction;
    private bool isLose;
    private bool isIncreasing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;

        OnStartGame?.Invoke();
        ChangeTargetRotate();

    }

    private void OnEnable()
    {
        LevelGenerator.OnCreateTarget += RefreshTarget;   
    }
    private void OnDisable()
    {
        LevelGenerator.OnCreateTarget -= RefreshTarget;   
    }

    private void Update()
    {
        if(isIncreasing)
        {
            IncreaseScale();
        }
    }

    public void OnDown()
    {
        isIncreasing = true;
    }
    public void OnUp()
    {
        isIncreasing = false;
        direction = currentTarget.position - transform.position ;
        CheckScale();
    }
    private void ChangeTargetRotate()
    {
        float valueZ = Mathf.Atan2(currentTarget.position.y - transform.position.y, currentTarget.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, valueZ), 0.1f);
    }

    private void IncreaseScale()
    {
        Vector3 value = birdBody.localScale * Time.deltaTime * 0.5f;
        birdBody.localScale += value;
    }

    private void RefreshTarget(Transform target)
    {
        lastTarget = currentTarget;
        currentTarget = target;
    }

    private void CheckScale()
    {
        float valueInner = currentTarget.GetComponent<Point>().innerCircle.transform.localScale.x; 
        float valueOut = currentTarget.GetComponent<Point>().outCircle.transform.localScale.x;

        float middle = ((valueOut - valueInner) / 2) + valueInner;

        if(birdBody.localScale.x > valueInner && birdBody.localScale.x <= valueOut)
        {

            MoveToTarget();

            StartCoroutine(EnableWings(speedMove));
            StartCoroutine(InPlace(speedMove));
            StartCoroutine(DestroyLastTarget(speedMove));
            
            if(birdBody.localScale.x > middle - 0.15f && birdBody.localScale.x < middle + 0.15f)
            {
                OnClearStrike?.Invoke();
            }
            else
            {
                OnMissStrike?.Invoke();
            }
            OnJumped?.Invoke();
        }
        else
        {
            isLose = true;
            clickBtn.SetActive(false);
            wingR.DOLocalRotate(Vector3.zero, speedOpenWings);
            wingL.DOLocalRotate(Vector3.zero, speedOpenWings);

            transform.DOMove(currentTarget.position, speedMove).SetEase(Ease.Linear).OnComplete(
                () => rb.AddForce(transform.up * 15f, ForceMode2D.Impulse)
            );
            
        }
    }

    private void MoveToTarget()
    {
        transform.DOMove(currentTarget.position, speedMove).OnComplete(
            () => birdBody.DOScale(startScale, speedMove));
    }    
    private void Dead()
    {
        OnDead?.Invoke();
        
        transform.position = new Vector2(0, -3.5f);
        birdBody.localScale = new Vector2(1, 1);
        rb.velocity = new Vector2(0, 0);

        wingR.DOLocalRotate(new Vector3(0, 0, -60f), speedOpenWings);
        wingL.DOLocalRotate(new Vector3(0, 0, 60f), speedOpenWings);
        clickBtn.SetActive(true);
        
        ChangeTargetRotate(); 
        OnStartGame?.Invoke();

        isLose = false;
    }


    private IEnumerator InPlace(float speed)
    {
        yield return new WaitForSeconds(speed);
        ChangeTargetRotate();
        OnPlace?.Invoke();
    }
    private IEnumerator EnableWings(float speed)
    {
        wingR.DOLocalRotate(Vector3.zero, speedOpenWings);
        wingL.DOLocalRotate(Vector3.zero, speedOpenWings);

        yield return new WaitForSeconds(speed);

        wingR.DOLocalRotate(new Vector3(0,0,-60f), speedOpenWings);
        wingL.DOLocalRotate(new Vector3(0,0, 60f), speedOpenWings);
    }
    private IEnumerator DestroyLastTarget(float speed)
    {
        yield return new WaitForSeconds(speed);
        Destroy(lastTarget.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DeadZone"))
        {
            Dead();
        }
    }

}
