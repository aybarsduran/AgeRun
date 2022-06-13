using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject road;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = road.transform.position.z -transform.position.z  ;


        if (distance < 35f)
        {
            Instantiate(road, new Vector3(0, 0, 0), Quaternion.identity);
            
        }
    }
}
