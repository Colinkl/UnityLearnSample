using System.Collections;
using UnityEngine;

public class RotationScript : BaseScript
{
    [SerializeField]
    [Min(0f)]
    private float rotationSpeed = 1f;

    [SerializeField]
    private Vector3 vect = new Vector3(0, 90, 0);

    private IEnumerator Rotate()
    {
        Quaternion targetAngle = transform.rotation * Quaternion.Euler(vect);
        while (Mathf.Abs(Quaternion.Angle(transform.rotation, targetAngle)) >= 5)
        {

            var currentAngle = transform.rotation.eulerAngles;
            var rotarionAngle = vect * rotationSpeed * Time.deltaTime;
            var targetAngleDelta = Mathf.Abs(Quaternion.Angle(transform.rotation, targetAngle));
            var incrementAngleDelta = Mathf.Abs(Quaternion.Angle(transform.rotation, Quaternion.Euler(rotarionAngle)* transform.rotation));
            if (targetAngleDelta <= incrementAngleDelta)
            {
                break;
            }

            transform.rotation = Quaternion.Euler(rotarionAngle) * transform.rotation;
            yield return null;
        }

        transform.rotation = targetAngle;
    }

    [ContextMenu("Rotate")]
    public override void Use()
    {
        StartCoroutine(Rotate());
    }
}
