using UnityEngine;

public class QuickDrawGameCanvasRelay : MonoBehaviour
{
    [SerializeField] NewQuickGameGame newQuickGameGame;
    [SerializeField] GameObject drawButton;
    public void DrawTimeRelay()
    {
        newQuickGameGame.DrawTime();
    }

    public void ResetGameRelay()
    {
        newQuickGameGame.ResetGame();
    }

    public void TurnOnDrawButton()
    {
        drawButton.SetActive(true);
    }
}