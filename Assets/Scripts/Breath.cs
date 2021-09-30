using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public Slider BreathTimer;
    public bool canBreath = true;
    public bool breathStop = false;
    
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
        Debug.Log($"Silder is {BreathTimer}");
        if (Input.GetKey(KeyCode.Q) && canBreath == true)
        {
            breathStop = true;
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
                    breathStop = false;
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
            BreathTimer.value += Time.deltaTime * 0.37f;
        if (BreathTimer.value == BreathTimer.maxValue && breathStop == false)
        {
            Debug.Log("Full");
            yield return canBreath = true;
        }
        yield return null;
    }
}