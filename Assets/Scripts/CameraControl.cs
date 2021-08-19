using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Transform camPos;

    public float distance = 25.0f;
    public float height = 50.0f;
    public float dampRotate = 0.0f;

    public bool isZoom = false;

    private void Awake()
    {
        camPos = GetComponent<Transform>();
    }
    
    void LateUpdate()
    {
        Zoom();
        CameraRotate();
    }
    private void Zoom()
    {
        //성공
        isZoom = true;
        
        Camera camera = Camera.main;
        float zoomSpeed = 10f;
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        
        if (distance != 0)
        {
            Debug.Log("Zoom");
            camera.fieldOfView += distance;
        }
    }
    private void CameraRotate()
    {
        float currentYAngle = Mathf.LerpAngle(camPos.eulerAngles.y, target.eulerAngles.y, dampRotate * Time.deltaTime);

        Quaternion rotate = Quaternion.Euler(0, currentYAngle, 0);

        camPos.position = target.position - (rotate * Vector3.forward * distance) + (Vector3.up * height);

        float rotateSpeed = 10f;
        if (Input.GetMouseButton(1))
        {
            Debug.Log("우클릭 회전");
            Vector3 rotation = transform.rotation.eulerAngles; // 현재 카메라의 각도를 Vector3로 반환
            rotation.y += Input.GetAxis("Mouse X") * rotateSpeed; // 마우스 X 위치 * 회전 스피드
            rotation.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // 마우스 Y 위치 * 회전 스피드
            Quaternion q = Quaternion.Euler(rotation); // Quaternion으로 변환
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // 자연스럽게 회전
        }

        if(Input.GetMouseButtonUp(1))
        {
            //다시 카메라를 원위치시킴
        }
        //캐릭터를 비스듬한 각도로 바라보는거 추가
    }
}