using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //우클릭을 하면 카메라 코드에 관여하여 줌 인, 인스턴트화 된 화살 프리팹을 생성한다
    CameraControl cameraControl;
    Breath breathTime;
    PlayerMove playerMove;

    void LockStart()
    {
        if (cameraControl.isZoom == true)
            StartCoroutine(Aim());
        playerMove.moveSpeed = 0.2f;
    }
    IEnumerator Aim()
    {
        yield return null;
    }
    void LockEnd()
    {
        if (breathTime.canBreath == false)
            StopCoroutine(Aim());
        playerMove.moveSpeed = 1f;
    }
}
