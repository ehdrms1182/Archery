using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //��Ŭ���� �ϸ� ī�޶� �ڵ忡 �����Ͽ� �� ��, �ν���Ʈȭ �� ȭ�� �������� �����Ѵ�
    CameraControl cameraControl;
    
    void LockStart()
    {
        if (cameraControl.isZoom == true)
            StartCoroutine(Aim());
    }
    IEnumerator Aim()
    {
        yield return null;
    }
}
