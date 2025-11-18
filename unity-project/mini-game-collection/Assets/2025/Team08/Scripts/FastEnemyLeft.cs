using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyLeft : MonoBehaviour
{
    //enemy's speed
    public float moveSpeed = 2f;
    public float jumpSpeed = 2f;

    Vector3 ogPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, -90);
        ogPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the enemy's position
        Vector3 currentPosition = transform.position;
        //moveSpeed = 5f * direction;
        currentPosition.x -= moveSpeed * Time.deltaTime;
        currentPosition.y += jumpSpeed * Time.deltaTime;
        transform.position = currentPosition;
        if (currentPosition.y > ogPosition.y + 3)
        {
            jumpSpeed *= -1;
        }
        if (currentPosition.y < ogPosition.y)
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
