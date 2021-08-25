using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAiming : MonoBehaviour
{
    //적을 조준하는 코드
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public Transform Arrow;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        StartCoroutine(SimulateProjectile());
    }


    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Arrow.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float targetDistance = Vector3.Distance(Arrow.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float arrowVelocity = targetDistance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(arrowVelocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(arrowVelocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = targetDistance / Vx;

        // Rotate projectile to face the target.
        Arrow.rotation = Quaternion.LookRotation(Target.position - Arrow.position);

        float elapseTime = 0;

        while (elapseTime < flightDuration)
        {
            Arrow.Translate(0, (Vy - (gravity * elapseTime)) * Time.deltaTime, Vx * Time.deltaTime);

            elapseTime += Time.deltaTime;

            yield return null;
        }
    }
}
