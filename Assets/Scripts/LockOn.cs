using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockOn : MonoBehaviour
{
    //��Ŭ���� �ϸ� ī�޶� �ڵ忡 �����Ͽ� �� ��, �ν���Ʈȭ �� ȭ�� �������� �����Ѵ�

    [SerializeField]
    CameraControl cameraControl;
    [SerializeField]
    Breath breathTime;
    [SerializeField]
    PlayerMove playerMove;

    private float reloadTime = 5;

    public GameObject arrowPrefab;
    public Transform arrowPosition;
    public Vector3 originPos;
    RaycastHit hit;

    public bool isLock = false;

    private void Start()
    {
        originPos = Vector3.zero;
        currentArrowCount = maxArrowCount;
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
        LockStart();
        LockEnd();
    }


    void LockStart()
    {
        
        if (cameraControl.isZoom == true)
        {
            StartCoroutine(Aim());
            isLock = true;
        }
        if (isLock == true)
            playerMove.moveSpeed = 0.5f;
    }
    void LockEnd()
    {
        if (breathTime.canBreath == false)
        {
            StopCoroutine(Aim());
            isLock = false;
        }
        if(isLock == false)
            playerMove.moveSpeed = 1f;
    }
    IEnumerator Aim()
    {
        Debug.Log("Aiming");

        //���ؼ� ǥ�� ���
        ShotArrow(reloadTime); //�ڷ�ƾ ���� ����
        //GameObject gameObject;
        //gameObject.SetActive(true);
        yield return null;
    }
    public float range; 
    public int maxArrowCount = 3;
    public int currentArrowCount;
    IEnumerator ShotArrow(float waitTime)
    {
        Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrowPosition.transform.position;
        Debug.Log("Ready");
        while(waitTime > 0.0f)
        {
            Debug.Log($"���� �ð� : {waitTime}");
            waitTime -= Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Fire1") && currentArrowCount > 0 && waitTime == 0.0f)//���� �ð� ��
        {
            Debug.Log("�߻�");
            GameObject arrow = Instantiate(arrowPrefab);//, Quaternion.Euler(dir));
            //arrowPrefab.transform.Translate(Vector3.forward * 2f);
            arrow.transform.position = arrowPosition.transform.position;
            arrow.transform.Translate(dir+Vector3.forward);
            currentArrowCount--;
            yield return reloadTime = 3;
        }
    }
}
