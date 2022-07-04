using UnityEngine;

public class CurrentLeftTarget : MonoBehaviour
{
    [SerializeField] Transform leftTarget;
    [SerializeField] CharacterJumpController characterJumpController;


    public void ChangeLeftTarget(Transform newLeftTarget)
    {
        leftTarget = newLeftTarget;
    }

    public void LeftJump()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterJumpController>().ChangeTargetPoint(leftTarget.position);
    }
}
