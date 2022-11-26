using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher_Controller : MonoBehaviour
{
    private Vector3 playerInput;
    // public GameObject enemy;
    [SerializeField] private Rigidbody playerRb;
    // public Rigidbody enemyRb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 360;
    public int kills, score;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // in fixed update rather than update is because we're using rigid body of player in these functions
        Move();
        Look();
    }

    private void Look() {
        if (playerInput != Vector3.zero)
        {
            // moving player forward depending upon the distance between us and the player input force on pressing key
            var relative = (transform.position + playerInput) - transform.position;
            // player rotation along y axis 
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            // to get contineous smooth rotation rather than snapping
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    // getting player input 
    void PlayerInput(){
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    // moving player forward in direction
    void Move()
    {
        playerRb.MovePosition(transform.position + (transform.forward * playerInput.magnitude) * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        // keeping the update clean
        PlayerInput();
    }

    // pushing player away after hitting them
    // void OnCollisionEnter(Collision col)
    // {
    //     if(col.gameObject.CompareTag("Col_Detect"))
    //     {
    //         Rigidbody enemyRb = col.gameObject.GetComponent<Rigidbody>();
    //         Vector3 awayFromPlayer = col.gameObject.transform.position - transform.position;
    //         enemyRb.AddForce(awayFromPlayer * 15.0f, ForceMode.Impulse);
    //     }
    // }

    // killing enemies and counting Kills and Score 
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            kills++;
            Debug.Log(kills);
            Destroy(col.gameObject);
            if(kills%25 == 0)
            {
                // can check score increasing on the inspector
                score++;
            }
        }
    }
}
