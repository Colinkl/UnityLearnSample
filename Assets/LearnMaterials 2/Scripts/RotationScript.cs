using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : BaseScript
{
    private const float rotationSpeed = 10f;
    private Vector3 vect = new Vector3(0,90,0);

    private IEnumerator Rotate()
    {
        Vector3 r = (vect - transform.eulerAngles ).normalized;

        while (Vector3.Angle(transform.eulerAngles, r) > 2*rotationSpeed * Time.deltaTime)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * r);
            yield return null;
        }

        transform.eulerAngles = vect;
    }   

    public override void Use()
    {
        StartCoroutine(Rotate());
    }
}
