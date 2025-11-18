using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.Games2025.Team08
{
    public class Enemies : MonoBehaviour
    {
        void Start()
        {

        }

        void Update()
        {
            if (transform.position.x >= -2 && transform.position.x <= 2)
            {
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}
