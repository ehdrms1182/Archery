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

    private void Update()
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

        if (Input.GetMouseButtonDown(1))    //��Ŭ�����϶�
        {
            if (distance != 0)
            {
                if (distance < 0)
                {
                    Debug.Log("Zoom");
                    cam.fieldOfView += distance;

                }
                if (cam.fieldOfView < 30)
                {
                    Debug.Log("Too many");
                    cam.fieldOfView = 60;
                }
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log("ZoomOut");
            cam.fieldOfView = 60;
        }
    }
    private void CameraRotation()
    {
        float rotateSpeed = 10f;
        // �¿�� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� �¿�� ȸ���� �� ���
        float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;
        cameraRotationY = Mathf.Clamp(cameraRotationY + yRotateSize, -90, 90);

        // ���Ʒ��� ������ ���콺�� �̵��� * �ӵ��� ���� ī�޶� ȸ���� �� ���(�ϴ�, �ٴ��� �ٶ󺸴� ����)
        float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
        cameraRotationX = Mathf.Clamp(cameraRotationX + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);
        
        // ī�޶� ���� �� �ε巴�� �����̰� ����(���� ����)
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles), 2f);
    }
    private void CameraFollow()
    {
        Vector3 cameraPos = target.transform.position + offset;
        Vector3 lerpPos = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        transform.position = lerpPos;
        //transform.LookAt(target.transform);
    }
}