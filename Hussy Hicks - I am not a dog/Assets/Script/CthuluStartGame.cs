using UnityEngine;

public class CthuluStartGame : MonoBehaviour
{
    [SerializeField] CthuluGame cthuluGame;
    public void StartCthuluGame()
    {
        cthuluGame.StartGame();
        GetComponentInChildren<CharacterAnimationOnly>().IdleAnimation();
    }
}
