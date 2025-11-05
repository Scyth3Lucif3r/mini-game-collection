using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //enemy's speed
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move the enemy's position
        Vector3 currentPosition = transform.position;
        //Edit this to determine direction
        currentPosition.y += moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
        //Delete Enemy once it's reached a certain point
        if (currentPosition.y >= 10) {
            Destroy(gameObject);
        }
    }
}

