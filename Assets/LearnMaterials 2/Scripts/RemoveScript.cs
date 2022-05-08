using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : BaseScript
{
    [SerializeField]
    [Min(0f)]
    private float speed = 1f;

    private Vector3 shrinkV = new Vector3(1, 1, 1);


    [ContextMenu("Use")]
    public override void Use()
    {
        StartCoroutine(RemoveChildsCoroutine());
    }

    public IEnumerator RemoveChildsCoroutine()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            {
                Transform c = transform.GetChild(i);
                while (c.localScale.x > 0)
                {
                    c.localScale -= shrinkV * Time.deltaTime * speed;
                    yield return null;
                }

                Destroy(c.gameObject);
                yield return null;
            }
        }
    }
}
