using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.x >= -2 && transform.position.x <= 2 )
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
