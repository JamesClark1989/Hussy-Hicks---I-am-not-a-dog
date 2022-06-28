using UnityEngine;

public class DivingGameCallback : MonoBehaviour
{
    [SerializeField] DivingGame divingGame;
    public void NextGame()
    {
        divingGame.StartNextGame();
    }
}
