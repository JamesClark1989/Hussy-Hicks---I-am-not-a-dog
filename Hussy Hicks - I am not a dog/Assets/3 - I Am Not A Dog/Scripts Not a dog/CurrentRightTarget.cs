using UnityEngine;

public class CurrentRightTarget : MonoBehaviour
{
    [SerializeField] Transform rightTarget;
    [SerializeField] CharacterJumpController characterJumpController;


    public void ChangeRightTarget(Transform newRightTarget)
    {
        rightTarget = newRightTarget;
    }

    public void RightJump()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterJumpController>().ChangeTargetPoint(rightTarget.position);
    }
}
