using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaScript : MonoBehaviour
{
    private List<BaseScript> scripts ;


    // Start is called before the first frame update
    void Start()
    {
        scripts = new List<BaseScript>();
        scripts.Add(gameObject.AddComponent<RotationScript>());
        scripts.Add(gameObject.AddComponent<MoveScript>());
        scripts.Add(gameObject.AddComponent<CopyScript>());
        scripts.Add(gameObject.AddComponent<RemoveScript>());

    }

    [ContextMenu("UseAll")]
    public void UseAll()
    {
        StartCoroutine(UseAllCoroutine());
    }

    public IEnumerator UseAllCoroutine()
    {
        foreach (var s in scripts)
        {
            s.Use();
            yield return new  WaitForSeconds(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
