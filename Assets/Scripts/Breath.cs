using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breath : MonoBehaviour
{
    public Slider BreathTimer;
    public bool canBreath = true;

    //�����̴� ���� ����

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