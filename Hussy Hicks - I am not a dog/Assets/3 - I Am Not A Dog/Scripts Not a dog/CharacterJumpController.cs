using UnityEngine;
using System.Collections;

public class CharacterJumpController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 targetPoint;
    [SerializeField] bool canMove = false;
    [SerializeField] bool stunned = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        targetPoint = GameObject.FindGameObjectWithTag("JumpTarget3").transform.position;

    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(targetPoint, transform.position);
        if (dist < 0.2f)
            canMove = true;
        else
        {
            canMove = false;
            MoveTowardsTarget(targetPoint);
        }

    }

    void MoveTowardsTarget(Vector3 target)
    {
        var offset = target - transform.position;

        offset.y += Physics.gravity.y;

        if (characterController.isGrounded)
        {
            offset.y = 0;
        }
        //Get the difference.
        if (offset.magnitude > .01f)
        {
            //If we're further away than .1 unit, move towards the target.
            //The minimum allowable tolerance varies with the speed of the object and the framerate. 
            // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
            
            offset = offset.normalized * moveSpeed;
            //normalize it and account for movement speed.
            characterController.Move(offset * Time.fixedDeltaTime);
            //actually move the character.
        }
    }

    public void ChangeTargetPoint(Vector3 newTargetPoint)
    {

        if (canMove == true && stunned == false)
        {
            anim.SetTrigger("Jump");
            targetPoint = newTargetPoint;
        }
    }


    public void Fall()
    {
        anim.SetTrigger("Fall");
        StartCoroutine(GetUp());
    }

    private IEnumerator GetUp()
    {

        stunned = true;
        yield return new WaitForSeconds(0.8f);
        stunned = false;
    }

    public void ForceChangeTargetPoint(Vector3 newTargetPoint)
    {
        targetPoint = newTargetPoint;
    }

    public void ReturnToStart(Transform startPos)
    {
        characterController.enabled = false;
        transform.position = startPos.position;
        ForceChangeTargetPoint(startPos.position);
        characterController.enabled = true;

    }
}
