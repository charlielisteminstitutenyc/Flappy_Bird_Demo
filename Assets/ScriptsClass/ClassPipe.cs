using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPipe : MonoBehaviour
{
    public float speed = 4f;
    public float endtime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Death());
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3.left = (-1,0,0)
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(endtime);
        Destroy(gameObject);
    }
}
