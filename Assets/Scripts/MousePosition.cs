using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Transform point = null;

    void Update()
    {
        MouseOn();
    }
    private void MouseOn()
    {
        Vector3 position = Input.mousePosition;
        position.z = Camera.main.farClipPlane;
        point.position = Camera.main.ScreenToWorldPoint(position);
    }
}

