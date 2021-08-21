using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform camPos;
   


    [SerializeField]
    private Camera cam;
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    public float distance = 25.0f;
    public float height = 50.0f;
    public float dampRotate = 0.0f;

    public bool isZoom = false;

    private void Awake()
    {
        camPos = GetComponent<Transform>();
        cam = Camera.main;
    }

    private void Update()
    {
        CameraRotate();
        //CameraRotation();
    }
    void LateUpdate()
    {
        Zoom();
    }
    private void Zoom()
    {
        //����
        isZoom = true;    
        float zoomSpeed = 10f;
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        
        if (distance != 0)
        {
            Debug.Log("Zoom");
            cam.fieldOfView += distance;
        }
    }

    private void CameraRotate()
    {
        //float currentYAngle = Mathf.LerpAngle(camPos.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

        //Quaternion rotate = Quaternion.Euler(0, currentYAngle, 0);

        float rotateSpeed = 10f;
        Vector3 rotation = transform.rotation.eulerAngles; // ���� ī�޶��� ������ Vector3�� ��ȯ
        rotation.y += Input.GetAxis("Mouse X") * rotateSpeed; // ���콺 X ��ġ * ȸ�� ���ǵ�
        rotation.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // ���콺 Y ��ġ * ȸ�� ���ǵ�

        rotation.x = Mathf.Clamp(rotation.x, 45, -45);
        Quaternion q = Quaternion.Euler(rotation); // Quaternion���� ��ȯ
        q.z = 0;
        camPos.position = target.position - (q * Vector3.forward * distance) + (Vector3.up * height);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // �ڿ������� ȸ��

        //ĳ���͸� �񽺵��� ������ �ٶ󺸴°� �߰�
    }


    //�۵��ҷ�
    //private void CameraRotation()
    //{
    //    float rotateSpeed = 10f;
    //    // ���� ī�޶� ȸ��
    //    float rotationX = Input.GetAxisRaw("Mouse Y");
    //    float cameraRotationX = rotationX * rotateSpeed;
    //    currentCameraRotationX -= cameraRotationX;
    //    currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
    //    cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    //}
}