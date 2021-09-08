using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("스피드 조정 변수")]
    public float moveSpeed;

    // 민감도
    [SerializeField]
    private float lookSensitivity;

    private float applySpeed = 1;

    // 카메라 한계
    [SerializeField]
    private float cameraRotationLimit;


    public Rigidbody myRigid;

    void Awake()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        CharacterRotation();
    }
    

    // 움직임 실행
    private void Move()
    {
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    // 좌우 캐릭터 회전
    private void CharacterRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(characterRotationY));
    }
}
