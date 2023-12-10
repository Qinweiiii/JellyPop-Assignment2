using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int livingPlayers = 2; // Set the initial number of living players
    

    // Method to call when a player dies
    public void PlayerDied()
    {
        livingPlayers--; // Decrement the number of living players

        if (livingPlayers <= 0)
        {
            // All players are dead, trigger game over
            GameOver();
        }
    }

    // Game over logic
    void GameOver()
    {
        
    }
}
