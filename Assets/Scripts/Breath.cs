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
                // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
                BreathTimer.value -= Time.deltaTime;
            }
            else if(BreathTimer.value == 0)
            {
                canBreath = false;
                //�� ȸ���ϱ� ��������
            }
            else
            {
                Debug.Log("Time is Zero.");
            }
        }
    }
}