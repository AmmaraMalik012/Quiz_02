using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Manager : MonoBehaviour
{
    // int width = 3;
    // int height = 3;
    // int[,] gridArray;
    float timeToMove = 0.2f;
    bool isMoving;
    [SerializeField] public GameObject tiles;
    Vector3 originalPos, targetPos;
    // Update is called once per frame
    void Start()
    {
        // tileSpawn();
    }
    void Update()
    {
        // playerInput();
        if(Input.GetKeyDown(KeyCode.W) && !isMoving)
        StartCoroutine(Move_Player (Vector3.up));

        if(Input.GetKeyDown(KeyCode.A) && !isMoving)
        StartCoroutine(Move_Player (Vector3.left));

        if(Input.GetKeyDown(KeyCode.S) && !isMoving)
        StartCoroutine(Move_Player (Vector3.down));

        if(Input.GetKeyDown(KeyCode.D) && !isMoving)
        StartCoroutine(Move_Player (Vector3.right));
    }

    // creating simple grid
    // void tileSpawn()
    // {
    //     gridArray = new int [width, height];
    //     for (int x = 0; x < gridArray.GetLength(0); x++)
    //     {
    //         for (int y = 0; y < gridArray.GetLength(1); y++)
    //         {
                
    //             Debug.Log(x + ", " + y);
    //             // spawnPos = new Vector2(x, y);
    //             // Instantiate(tiles, spawnPos, Quaternion.identity);
    //         }
    //     }
    // }
    // void playerInput()
    // {
    //     if(Input.GetKeyDown(KeyCode.W) && !isMoving)
    //     StartCoroutine(Move_Player (Vector3.up));
    //     if(Input.GetKeyDown(KeyCode.A) && !isMoving)
    //     StartCoroutine(Move_Player (Vector3.left));
    //     if(Input.GetKeyDown(KeyCode.S) && !isMoving)
    //     StartCoroutine(Move_Player (Vector3.down));
    //     if(Input.GetKeyDown(KeyCode.D) && !isMoving)
    //     StartCoroutine(Move_Player (Vector3.right));
    // }

    IEnumerator Move_Player(Vector3 direction)
    {
        isMoving = true;
        float elapsedTime = 0;
        originalPos = transform.position;
        targetPos = originalPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
