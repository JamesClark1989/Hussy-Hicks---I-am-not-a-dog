using UnityEngine;

public class ScorpionTimerRelay : MonoBehaviour
{
    [SerializeField] ScorpionController scorpionController;
    public void ResetTimer()
    {
        scorpionController.ResetTimerAfterAttack();
    }
}
