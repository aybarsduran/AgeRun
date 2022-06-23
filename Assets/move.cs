using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector3 target;
    Vector3 rotateTarget;
    // Start is called before the first frame update
    void Start()
    {
       target = new Vector3(1, 1, 1);
       rotateTarget = new Vector3(0, 30, 0);
    }

    // Update is called once per frame
    void Update()
    {
       transform.position= Vector3.MoveTowards(transform.position, target, 2 * Time.deltaTime);
        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, rotateTarget,2* Time.deltaTime);
    }
}
