using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("���ǵ� ���� ����")]
    public float moveSpeed;

    // �ΰ���
    [SerializeField]
    private float lookSensitivity;

    private float applySpeed = 1;

    // ī�޶� �Ѱ�
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
    

    // ������ ����
    private void Move()
    {
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    // �¿� ĳ���� ȸ��
    private void CharacterRotation()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(characterRotationY));
    }
}
