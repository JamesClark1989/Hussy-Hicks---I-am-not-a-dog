using UnityEngine;

public class QuickDrawPlayerParent : MonoBehaviour
{

    [SerializeField] NewQuickGameGame newQuickDrawGame;

    public void StartRoundRelay()
    {
        newQuickDrawGame.StartRoundCountdown();
    }

    public void StopRunningRelay()
    {
        newQuickDrawGame.StopRunning();
    }
}
