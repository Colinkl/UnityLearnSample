using System.Collections;
using UnityEngine;

public class MoveScript : BaseScript
{
    [SerializeField]
    public float velocity = 1f;

    [SerializeField]
    private Vector3 dest = new Vector3(3, 0, 0);

    IEnumerator Move()
    {
        Vector3 t = (dest - transform.position).normalized;

        while (Vector3.Distance(transform.position, dest) > 2f * Time.deltaTime)
        {
            transform.position += t * velocity * Time.deltaTime;
            yield return null;

        }

        transform.position = dest;

    }

    [ContextMenu("Go")]
    public override void Use()
    {
        StartCoroutine(Move());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
