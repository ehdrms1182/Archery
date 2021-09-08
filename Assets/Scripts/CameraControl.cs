using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;

    public Vector3 offset;

    public bool isZoom = false;

    [SerializeField]
    private Camera cam;
    private float cameraRotationX = 0;
    private float cameraRotationY = 0;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        CameraRotation();
    }
    void LateUpdate()
    {
        CameraFollow();
        Zoom();
    }
    private void Zoom()
    {
        //����
        isZoom = true;
        float zoomSpeed = 10f;
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

        if (Input.GetMouseButton(1))    //��Ŭ�����϶�
        {
            distance = Mathf.Clamp(distance, 30, 60);
            if (distance != 0)
            {
                Debug.Log("Zoom");
                //cam.fieldOfView += distance;
                Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, distance, Time.deltaTime * 2.7f);
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log("ZoomOut");
            cam.fieldOfView = 60;
            //Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 2.7f);
        }
    }
    //private void CameraRotation()
    //{
    //    float rotateSpeed = 7f;
    //    // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
    //    float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
    //    // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
    //    float yRotate = transform.eulerAngles.y + yRotateSize;

    //    // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
    //    transform.eulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);

    //    // ī�޶� ���� �� �ε巴�� �����̰� ����(���� ����)
    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles), 2f);
    //}

    // ī�޶� �Ѱ�
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    private float currentCameraRotationY = 360;
    private void CameraRotation()
    {
        float lookSensitivity = 1;

        float xRotation = Input.GetAxisRaw("Mouse Y");
        float yRotation = Input.GetAxisRaw("Mouse X");
        
        float cameraRotationX = xRotation * lookSensitivity;
        float cameraRotationY = yRotation * lookSensitivity;

        currentCameraRotationY += cameraRotationY;

        currentCameraRotationX -= cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);


        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, currentCameraRotationY, 0f);
    }

    private void CameraFollow()
    {
        Vector3 cameraPos = target.transform.position + offset;
        Vector3 lerpPos = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        transform.position = lerpPos;
        //transform.LookAt(target.transform);
    }
}