using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    float force = 0f;
    Vector3 offset = Vector3.zero;
    Quaternion originRotate;

    private void Awake()
    {
        originRotate = transform.rotation;
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 originEuler = transform.eulerAngles;
        while(true)
        {
            float rotateX = Random.RandomRange(-offset.x, offset.x);
            float rotateY = Random.RandomRange(-offset.y, offset.y);
            float rotateZ = Random.RandomRange(-offset.z, offset.z);

            Vector3 randomRotate = originEuler + new Vector3(rotateX, rotateY, rotateZ);
            Quaternion rotation = Quaternion.Euler(randomRotate);

            while (Quaternion.Angle(transform.rotation, rotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, force * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(ShakeCoroutine());
        }
    }
}
