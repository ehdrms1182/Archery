using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimAi : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    private int touchCount = 0;
    Animator animator;


    bool isSwim = false;

    private void OnCollisionEnter(Collision collision)
    {
        touchCount++;
        speed *= -1;
        if(touchCount == 3)
        {
            speed = 0;
            isSwim = false;
            Debug.Log("End");
        }
    }
    private void Awake()
    {
        isSwim = true;
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        AiMove();
    }
    private void AiMove()
    {
        if(touchCount < 3 && isSwim)  
        {
            //가는 방향따라 설정(x,y,z)
            transform.Translate(0,0, -speed*Time.deltaTime,Space.World);
        }
    }
}
