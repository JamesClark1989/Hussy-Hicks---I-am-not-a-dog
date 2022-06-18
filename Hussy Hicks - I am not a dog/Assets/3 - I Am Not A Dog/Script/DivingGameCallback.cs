using UnityEngine;

public class DivingGameCallback : MonoBehaviour
{
    [SerializeField] DivingGame divingGame;
    public void NextGame()
    {
        if(divingGame.CheckGameCounter() < 3)
        {
            divingGame.StartNextGame();
        }
    }
}
