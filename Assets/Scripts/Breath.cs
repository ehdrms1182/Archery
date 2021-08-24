using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public Slider BreathTimer;
    public bool canBreath = true;

    void Awake()
    {
        BreathTimer = GetComponent<Slider>();
    }
    private void Start()
    {
        BreathTimer = FindObjectOfType<Slider>();
    }
    void Update()
    {
        BreathOn();
    }
    void BreathOn()
    {
        Debug.Log($"Silder is {BreathTimer}"); //슬라이더 적용 체크 <- 게임 시작시 Silder가 none으로 바뀌는 버그
        if (Input.GetKey(KeyCode.Q) && canBreath == true)
        {
            if (BreathTimer.value > 0)
            {
                // 시간이 변경한 만큼 slider Value 변경을 합니다.
                BreathTimer.value -= Time.deltaTime;
                Debug.Log("Stop Breathing");
            }
            else
            {
                
                Debug.Log($"Time is {BreathTimer.value}");
                if (BreathTimer.value == BreathTimer.minValue)
                {
                    Debug.Log("End");
                    canBreath = false;
                }
                return;
            }
        }
        else
        {
            if (BreathTimer.value == BreathTimer.maxValue)
                StopCoroutine(ReBreath());
            else
            {
                Debug.Log("ReBreathing...");
                StartCoroutine(ReBreath());
            }

        }
    }
    
    IEnumerator ReBreath()
    {
        if (BreathTimer.value != BreathTimer.maxValue)
            BreathTimer.value += Time.deltaTime * 0.7f;
        if (BreathTimer.value == BreathTimer.maxValue)
        {
            Debug.Log("Full");
            yield return canBreath = true;
        }
        yield return null;
    }
}