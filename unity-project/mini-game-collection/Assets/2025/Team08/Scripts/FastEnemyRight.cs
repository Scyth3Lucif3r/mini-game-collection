using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyRight : MonoBehaviour
{

    //enemy's speed
    public float moveSpeed = 4f;
    public float jumpSpeed = 4f;

    Vector3 ogPosition;
    // Start is called before the first frame update
    void Start()
    {
        ogPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the enemy's position
        Vector3 currentPosition = transform.position;
        //moveSpeed = 5f * direction;
        //Edit this to determine direction
        currentPosition.x -= moveSpeed * Time.deltaTime;
        currentPosition.y += jumpSpeed * Time.deltaTime;
        if (currentPosition.y > ogPosition.y + 5 || currentPosition.y < ogPosition.y - 5)
        {
            jumpSpeed *= -1;
        }
        //Delete Enemy once it's reached a certain point
        if (currentPosition.x >= -1 && currentPosition.x <= 1)
        {
            Destroy(gameObject);
        }
    }
}
