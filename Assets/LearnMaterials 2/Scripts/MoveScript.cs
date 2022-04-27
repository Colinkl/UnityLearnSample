using System.Collections;
using UnityEngine;

public class MoveScript : BaseScript
{
    public float velocity = 1f;

    [SerializeField]
    private Vector3 dest = new Vector3(3, 0, 0);

    IEnumerator Move()
    {
        Vector3 t = (dest - transform.position).normalized;

        while (Vector3.Distance(transform.position, dest) > 20f * Time.deltaTime)
        {
            transform.position += Time.deltaTime * velocity * t;
            yield return null;

        }

        transform.position = dest;

    }

    [ContextMenu("Go")]
    public override void Use()
    {
        StartCoroutine(Move());
    }
}
