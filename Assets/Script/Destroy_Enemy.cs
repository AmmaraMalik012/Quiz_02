using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Enemy : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // destroy enemy
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
