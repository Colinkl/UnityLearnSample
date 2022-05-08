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
        Quaternion r = transform.rotation * Quaternion.Euler(vect);
        var xxx = Quaternion.Angle(transform.rotation, r);
        while (Mathf.Abs(Quaternion.Angle(transform.rotation, r)) >= 5)
        {

            var c = transform.rotation.eulerAngles;
            var rot = vect * rotationSpeed * Time.deltaTime;
            var f = Quaternion.Euler(rot) * transform.rotation;
            var t = Mathf.Abs(Quaternion.Angle(transform.rotation, r));
            var d = Mathf.Abs(Quaternion.Angle(transform.rotation, Quaternion.Euler(rot)* transform.rotation));
            if (t <= d)
            {
                break;
            }

            transform.rotation = Quaternion.Euler(rot) * transform.rotation;
            yield return null;
        }

        transform.rotation = r;
    }

    [ContextMenu("Rotate")]
    public override void Use()
    {
        StartCoroutine(Rotate());
    }
}
