using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    Slider BreathTimer;
    public bool canBreath = true;

    void Start()
    {
        BreathTimer = GetComponent<Slider>();
    }

    void Update()
    {
        BreathOn();
    }
    void BreathOn()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (BreathTimer.value > 0.0f)
            {
                // 시간이 변경한 만큼 slider Value 변경을 합니다.
                BreathTimer.value -= Time.deltaTime;
            }
            else if(BreathTimer.value == 0)
            {
                canBreath = false;
                //숨 회복하기 만들어야함
            }
            else
            {
                Debug.Log("Time is Zero.");
            }
        }
    }
}