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
        //성공
        isZoom = true;
        float zoomSpeed = 10f;
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;

        if (Input.GetMouseButton(1))    //우클릭중일때
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
    //    // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
    //    float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
    //    // 현재 y축 회전값에 더한 새로운 회전각도 계산
    //    float yRotate = transform.eulerAngles.y + yRotateSize;

    //    // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
    //    transform.eulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);

    //    // 카메라를 더욱 더 부드럽게 움직이게 해줌(비선형 보간)
    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles), 2f);
    //}

    // 카메라 한계
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