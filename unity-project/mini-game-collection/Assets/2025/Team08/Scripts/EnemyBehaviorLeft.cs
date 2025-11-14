using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorLeft : MonoBehaviour
{

    //enemy's speed
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the enemy's position
        Vector3 currentPosition = transform.position;
        //moveSpeed = 5f * direction;
        //Edit this to determine direction
        currentPosition.x -= moveSpeed * Time.deltaTime;
        transform.position = currentPosition;
        //Delete Enemy once it's reached a certain point
        if (currentPosition.x >= -1 && currentPosition.x <= 1)
        {
            Destroy(gameObject);
        }
    }
}
