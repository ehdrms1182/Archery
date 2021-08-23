using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigid;

    public float moveSpeed = 1;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        CharacterRotation();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 moveHorizontal = transform.right * h;
        Vector3 moveVertical = transform.forward * v;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * moveSpeed;

        rigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }
    private void CharacterRotation()
    {
        // 좌우 캐릭터 회전
        float rotationY = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, rotationY, 0f) * moveSpeed;

       

        rigid.MoveRotation(rigid.rotation * Quaternion.Euler(characterRotationY));
    }
}
