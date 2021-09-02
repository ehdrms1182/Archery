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
    //    cameraRotationY = Mathf.Clamp(cameraRotationY + yRotateSize, -90, 90);

    //    // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
    //    float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpeed;
    //    // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
    //    // Clamp 는 값의 범위를 제한하는 함수
    //    cameraRotationX = Mathf.Clamp(cameraRotationX + xRotateSize, -45, 80);
    //    //카메라 위로 회전시,캐릭터도 같이 움직여버림

    //    // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
    //    transform.eulerAngles = new Vector3(cameraRotationX, cameraRotationY, 0);

    //    // 카메라를 더욱 더 부드럽게 움직이게 해줌(비선형 보간)
    //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.eulerAngles), 2f);
    //}

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;
    private void CameraRotation()
    {
        float lookSensitivity = 1;
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
        cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
    private void CameraFollow()
    {
        Vector3 cameraPos = target.transform.position + offset;
        Vector3 lerpPos = Vector3.Lerp(transform.position, cameraPos, 0.2f);
        transform.position = lerpPos;
        //transform.LookAt(target.transform);
    }
}