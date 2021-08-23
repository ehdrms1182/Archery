using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //우클릭을 하면 카메라 코드에 관여하여 줌 인, 인스턴트화 된 화살 프리팹을 생성한다
    CameraControl cameraControl;
    Breath breathTime;
    PlayerMove playerMove;
    
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
        yield return null;
    }
    private void Update()
    {
        LockStart();
        LockEnd();
    }
}
