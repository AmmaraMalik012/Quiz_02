using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch_Projectile : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectile;
    public float launchVelocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var projectilePrefab = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
            projectilePrefab.GetComponent<Rigidbody>().velocity = launchPoint.up * launchVelocity;
        }
    }
}
