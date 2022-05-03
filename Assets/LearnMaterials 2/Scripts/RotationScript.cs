using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : BaseScript
{
    [SerializeField]
    private const float rotationSpeed = 1f;

    [SerializeField]
    private Vector3 vect = new Vector3(0,90,0);

    private IEnumerator Rotate()
    {
        Quaternion r = transform.rotation * Quaternion.Euler(vect);
        var xxx = Quaternion.Angle(transform.rotation, r);
        while (Quaternion.Angle(transform.rotation, r) > 0.1*rotationSpeed)
        {
            var c = transform.rotation.eulerAngles;
            var rot = vect * rotationSpeed * Time.deltaTime;
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
