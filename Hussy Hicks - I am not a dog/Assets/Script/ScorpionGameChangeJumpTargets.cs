using UnityEngine;

public class ScorpionGameChangeJumpTargets : MonoBehaviour
{
    [SerializeField] Transform targetLeft;
    [SerializeField] Transform targetRight;

    [SerializeField] CurrentLeftTarget currentLeftTarget;
    [SerializeField] CurrentRightTarget currentRightTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentRightTarget.ChangeRightTarget(targetRight);
            currentLeftTarget.ChangeLeftTarget(targetLeft);
        }
    }
}
