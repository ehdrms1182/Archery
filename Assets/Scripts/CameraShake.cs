using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float force = 0f;
    Vector3 offset = Vector3.zero;
    Quaternion originRotate;

    Breath breathCheck;
    LockOn lockCheck;

    private void Awake()
    {
        originRotate = transform.rotation;
    }
    IEnumerator ShakeCoroutine()
    {
        Vector3 originEuler = transform.eulerAngles;
        while(true)
        {
            float rotateX = Random.Range(-offset.x, offset.x);
            float rotateY = Random.Range(-offset.y, offset.y);
            float rotateZ = Random.Range(-offset.z, offset.z);

            float shakeSize = 1f;
            Vector3 randomRotate = originEuler + new Vector3(rotateX, rotateY, rotateZ);
            Quaternion rotation = Quaternion.Euler(randomRotate);

            while (Quaternion.Angle(transform.rotation, rotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, force * shakeSize *Time.deltaTime);
                if (!(breathCheck.canBreath == true && lockCheck.isLock == true))
                {
                    shakeSize -= Time.deltaTime;
                    //점차 감소시킨다
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, force * shakeSize * Time.deltaTime);
                    yield return null;
                }
                else
                    StopCoroutine(ShakeCoroutine());
                yield return null;
            }

            yield return null;
        }
    }

    private IEnumerator Reset()
    {
        while (Quaternion.Angle(transform.rotation, originRotate) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, originRotate, force * Time.deltaTime);
        }
        yield return null;
    }

    void Update()
    {
        if (lockCheck.isLock == true && breathCheck.breathStop == false)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }
}
