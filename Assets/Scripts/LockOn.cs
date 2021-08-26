using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //우클릭을 하면 카메라 코드에 관여하여 줌 인, 인스턴트화 된 화살 프리팹을 생성한다

    CameraControl cameraControl;
    Breath breathTime;
    PlayerMove playerMove;
    
    public GameObject arrowPrefab;
    public Transform arrowPosition;

    public bool isLock = false;

    private void Update()
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
        if (cameraControl.isZoom == true)//에러
        {
            StartCoroutine(Aim());
            isLock = true;
        }
        if (isLock == true)
            playerMove.moveSpeed = 0.5f;
    }
    void LockEnd()
    {
        GameObject.Find("");
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
        yield return null;
    }


    void Shot()
    {
        //GameObject instance = 
            Instantiate(arrowPrefab,transform.position,transform.rotation);
        if(Input.GetButtonDown("Fire0"))
        {
            Debug.Log("zz");
            StartCoroutine(ShotArrow());
        }
    }
    IEnumerator ShotArrow()
    {
        arrowPosition.Translate(Vector3.forward * 1f);

        yield return new WaitForSecondsRealtime(5f);
    }
}