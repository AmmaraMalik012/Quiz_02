using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float life = 1f;
    public int kill = 0;
    public int score = 0;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Kills: " + kill);
            Debug.Log("Score: " + score);
            kill++;
            Destroy(other.gameObject);
            if(kill%25 == 0)
            {
                score++;
            }
        }
    }

}
