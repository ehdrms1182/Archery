using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosColor : MonoBehaviour
{
    public Color color = Color.green; //Gizmos 색
    protected float radius = 1f; //구의 반지름

    // 사용시 함수 2개중 1개 주석처리하고 사용

    void OnDrawGizmos() // 씬 화면 상에서 항상 보이는 설정
    {
        // Gizmos 색 변경
        Gizmos.color = color;
        // 구 모양의 Gizmos 생성
        Gizmos.DrawSphere(transform.position, radius); //Gizmos 생성 위치와 반지름을 인자값으로 준다
    }
}
