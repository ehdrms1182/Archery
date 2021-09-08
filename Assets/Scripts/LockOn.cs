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
    private WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(5f);

    public GameObject arrowPrefab;
    public Transform arrowPosition;

    public bool isLock = false;

    private void FixedUpdate()
    {
        RaycastHit hit;
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
        Shot();
        //GameObject gameObject;
        //gameObject.SetActive(true);
        yield return null;
    }


    void Shot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("화살 발사");
            StartCoroutine(ShotArrow());
        }
    }
    IEnumerator ShotArrow()
    {
        Vector3 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - arrowPosition.position);
        Instantiate(arrowPrefab, transform.position, transform.rotation);
        arrowPrefab.transform.Translate(dir.normalized * 4f * Time.deltaTime);
        yield return waitForSecondsRealtime;
    }
}
