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
        Debug.Log($"Silder is {BreathTimer}"); //�����̴� ���� üũ <- ���� ���۽� Silder�� none���� �ٲ�� ����
        if (Input.GetKey(KeyCode.Q) && canBreath == true)
        {
            if (BreathTimer.value > 0)
            {
                // �ð��� ������ ��ŭ slider Value ������ �մϴ�.
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