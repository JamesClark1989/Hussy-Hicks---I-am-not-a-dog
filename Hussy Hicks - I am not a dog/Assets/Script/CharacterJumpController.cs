using UnityEngine;

public class CharacterJumpController : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;
    [SerializeField] Vector3 targetPoint;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        targetPoint = GameObject.FindGameObjectWithTag("JumpTarget3").transform.position;

    }

    void Update()
    {

        MoveTowardsTarget(targetPoint);
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
            characterController.Move(offset * Time.deltaTime);
            //actually move the character.
        }
    }

    public void ChangeTargetPoint(Vector3 newTargetPoint)
    {
        anim.SetTrigger("Jump");
        targetPoint = newTargetPoint;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Death"))
        {
            //Destroy(gameObject);
            //GameManager.instance.ReloadAnimation();
        }
    }
}
