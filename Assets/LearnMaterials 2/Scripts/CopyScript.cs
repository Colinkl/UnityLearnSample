using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : BaseScript
{
    [SerializeField]
    private GameObject target;
    private GameObject targerInh;

    [SerializeField]
    [Min(1)]
    private int count = 1;

    [SerializeField]
    private float step;
    private Vector3 location = new Vector3 (0, 0, 0);

    [ContextMenu("Use")]
    public override void Use()
    {
        Copy();
    }

    public void Copy()
    {
        location = transform.position;
        for (int i = 0; i < count; i++)
        {
            location.z +=step;
            targerInh = Instantiate(target, location, Quaternion.identity);
        }
    }
}
