using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSections : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter(Collision other)
    {
        
    
        if (other.gameObject.CompareTag("Section"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
        }
      
    }
}
