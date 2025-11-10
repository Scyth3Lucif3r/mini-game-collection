using MiniGameCollection.Games2025.Team00;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniGameCollection.Games2025.Team08
{
    public class MainMenu : MonoBehaviour
    { 
        public GameObject GameUI;
        public GameObject StartGameUI;
        public GameObject P1Ready;
        public GameObject P2Ready;
        public bool p1Ready = false;
        public bool p2Ready = false;

        void Update()
        {
            // Player 1 Press Button
            if (ArcadeInput.Players[(int)PlayerID.Player1].Action1.Pressed || ArcadeInput.Players[(int)PlayerID.Player1].Action2.Pressed)
            {
                P1Ready.GetComponent<TextMeshProUGUI>().text = "Player 1: Ready";
                Debug.Log("Player 1 pressed START/FIRE");
                p1Ready = true;
            }

            // Player 2 Press Button
            if (ArcadeInput.Players[(int)PlayerID.Player2].Action1.Pressed || ArcadeInput.Players[(int)PlayerID.Player2].Action2.Pressed)
            {
                p2Ready = true;
                P2Ready.GetComponent<TextMeshProUGUI>().text = "Player 2: Ready";
                Debug.Log("Player 2 pressed START/FIRE");
            }
            if (p1Ready && p2Ready)
            {
                SceneManager.LoadScene("Survive_60_Seconds");
            }
            
        }
    }
}
