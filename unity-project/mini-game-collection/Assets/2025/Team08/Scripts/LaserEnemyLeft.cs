using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGameCollection.Games2025.Team08
{
    public class LaserEnemyLeft : MonoBehaviour
    {
        //enemy's speed
        public float moveSpeed = 1f;
        int fireTimer = 0;
        public GameObject laser;
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
            currentPosition.x -= moveSpeed * Time.deltaTime;
            transform.position = currentPosition;
            //Delete Enemy once it's reached a certain point
            if (currentPosition.x >= -1 && currentPosition.x <= 1)
            {
                Destroy(gameObject);
            }
        }

        public void Wait()
        {
            fireTimer++;
            if (fireTimer % 100 == 0)
            {
                FireLaser();
            }
        }

        public void FireLaser()
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
