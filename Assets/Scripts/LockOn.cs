using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //��Ŭ���� �ϸ� ī�޶� �ڵ忡 �����Ͽ� �� ��, �ν���Ʈȭ �� ȭ�� �������� �����Ѵ�
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
