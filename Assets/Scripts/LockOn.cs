using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockOn : MonoBehaviour
{
    //우클릭을 하면 카메라 코드에 관여하여 줌 인, 인스턴트화 된 화살 프리팹을 생성한다

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

        //조준선 표시 기능
        ShotArrow(reloadTime); //코루틴 진입 에러
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
            Debug.Log($"남은 시간 : {waitTime}");
            waitTime -= Time.fixedDeltaTime;
        }

        if (Input.GetButtonDown("Fire1") && currentArrowCount > 0 && waitTime == 0.0f)//남은 시간 비교
        {
            Debug.Log("발사");
            GameObject arrow = Instantiate(arrowPrefab);//, Quaternion.Euler(dir));
            //arrowPrefab.transform.Translate(Vector3.forward * 2f);
            arrow.transform.position = arrowPosition.transform.position;
            arrow.transform.Translate(dir+Vector3.forward);
            currentArrowCount--;
            yield return reloadTime = 3;
        }
    }
}
