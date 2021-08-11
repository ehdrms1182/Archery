using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosColor : MonoBehaviour
{
    public Color color = Color.green; //Gizmos ��
    protected float radius = 1f; //���� ������

    // ���� �Լ� 2���� 1�� �ּ�ó���ϰ� ���

    void OnDrawGizmos() // �� ȭ�� �󿡼� �׻� ���̴� ����
    {
        // Gizmos �� ����
        Gizmos.color = color;
        // �� ����� Gizmos ����
        Gizmos.DrawSphere(transform.position, radius); //Gizmos ���� ��ġ�� �������� ���ڰ����� �ش�
    }
}
