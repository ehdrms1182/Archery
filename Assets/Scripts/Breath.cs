using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public Slider BreathTimer;
    public bool canBreath = true;

    //슬라이더 지정 오류

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
                StartCoroutine(ReBreath());
                return;
            }
            else
            {
                Debug.Log($"Time is {BreathTimer.value}");
            }
        }
    }
    IEnumerator ReBreath()
    {
        BreathTimer.value += Time.deltaTime;
        yield return null;
    }
}