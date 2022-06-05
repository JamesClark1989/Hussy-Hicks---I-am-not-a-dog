using UnityEngine;

public class StartGolfGame : MonoBehaviour
{
    [SerializeField] GolfGame golfGame;
    
    public void StartGolfGameNow()
    {
        golfGame.StartGame();
    }
}
