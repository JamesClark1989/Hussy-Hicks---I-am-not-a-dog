using UnityEngine;

public class QuickDrawGameCanvasRelay : MonoBehaviour
{
    [SerializeField] NewQuickGameGame newQuickGameGame;
    public void DrawTimeRelay()
    {
        newQuickGameGame.DrawTime();
    }

    public void ResetGameRelay()
    {
        newQuickGameGame.ResetGame();
    }
}