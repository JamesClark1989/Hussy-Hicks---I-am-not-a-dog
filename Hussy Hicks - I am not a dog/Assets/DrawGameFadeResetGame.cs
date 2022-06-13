
using UnityEngine;

public class DrawGameFadeResetGame : MonoBehaviour
{
    [SerializeField] QuickDrawGame quickDrawGame;
    
    public void ResetGame()
    {
        quickDrawGame.ResetGame();
    }
}
