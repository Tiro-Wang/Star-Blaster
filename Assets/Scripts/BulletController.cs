using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float speed = 10.0f;

    private float liveTime = 2.0f;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(WaitToDie());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed*Time.deltaTime,Space.Self);
    }
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(gameObject);
    }
}
