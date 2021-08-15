using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{
    //우클릭을 하면 카메라 코드에 관여하여 줌 인, 인스턴트화 된 화살 프리팹을 생성한다
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
