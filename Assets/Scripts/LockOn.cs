using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //��Ŭ���� �ϸ� ī�޶� �ڵ忡 �����Ͽ� �� ��, �ν���Ʈȭ �� ȭ�� �������� �����Ѵ�
    CameraControl cameraControl;
    Breath breathTime;
    PlayerMove playerMove;
    
    public GameObject arrowPrefab;


    bool isLock = false;

    void LockStart()
    {
        if (cameraControl.isZoom == true)
        {
            StartCoroutine(Aim());
            isLock = true;
        }
        playerMove.moveSpeed = 0.2f;
    }
    void LockEnd()
    {
        if (breathTime.canBreath == false)
        {
            StopCoroutine(Aim());
            isLock = false;
        }
        playerMove.moveSpeed = 1f;
    }
    IEnumerator Aim()
    {
        Debug.Log("Aiming");
        isLock = true;
        
        yield return null;
    }
    private void Update()
    {
        LockStart();
        LockEnd();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Abs(10)))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }

    void Shot()
    {
        GameObject instance = Instantiate(arrowPrefab);
        
    }
}
