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

        //���ؼ� ǥ�� ���
        Shot();
        //GameObject gameObject;
        //gameObject.SetActive(true);
        yield return null;
    }


    void Shot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("ȭ�� �߻�");
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
