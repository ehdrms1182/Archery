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
        //����
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
            Debug.Log("��Ŭ�� ȸ��");
            Vector3 rotation = transform.rotation.eulerAngles; // ���� ī�޶��� ������ Vector3�� ��ȯ
            rotation.y += Input.GetAxis("Mouse X") * rotateSpeed; // ���콺 X ��ġ * ȸ�� ���ǵ�
            rotation.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed; // ���콺 Y ��ġ * ȸ�� ���ǵ�
            Quaternion q = Quaternion.Euler(rotation); // Quaternion���� ��ȯ
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f); // �ڿ������� ȸ��
        }

        if(Input.GetMouseButtonUp(1))
        {
            //�ٽ� ī�޶� ����ġ��Ŵ
        }
        //ĳ���͸� �񽺵��� ������ �ٶ󺸴°� �߰�
    }
}