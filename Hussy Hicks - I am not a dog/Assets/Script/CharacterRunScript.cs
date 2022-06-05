using UnityEngine;
using Cinemachine;
using System.Collections;

public class CharacterRunScript : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed;
    [SerializeField] float speedMax;
    [SerializeField] bool running;
    //[SerializeField] float gravity = 9.8f;

    [SerializeField] Animator anim;
    public Vector3 moveDirection;

    [SerializeField] Transform spawn;
    public Transform camPos;

    bool canShoot = true;

    void Update()
    {

        moveDirection = new Vector3(speed, 0f, 0f);

        moveDirection.y += Physics.gravity.y;

        if (characterController.isGrounded)
        {
            moveDirection.y = 0;

            if (running)
            {
                speed = speedMax;
                anim.SetBool("Running", true);
            }
            else
            {
                speed = 0;
                anim.SetBool("Running", false);
            }
        }

        characterController.Move(moveDirection * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Death"))
        {
            Destroy(gameObject);
            GameManager.instance.ReloadAnimation();
        }
    }


    public void Run()
    {
        running = true;
    }

    public void DontRun()
    {
        running = false;
    }

    public void RunSetSpeed(float newSpeed)
    {
        speedMax = newSpeed;
        running = true;
    }

    public void DrawReadyPosition()
    {
        anim.SetTrigger("Quick Draw");
    }

    public void DrawGun()
    {
        anim.SetTrigger("Draw");
    }

    public void CharacterShoot()
    {
        if (canShoot)
        {
            QuickDrawGame qdg = FindObjectOfType<QuickDrawGame>();
            qdg.CharacterShootFirst();
        }
    }

    public void CowboyShot()
    {
        canShoot = false;
        anim.SetBool("Lost Draw", true);
        StartCoroutine("DelayedLevelReload");
    }

    private IEnumerator DelayedLevelReload()
    {
        yield return new WaitForSeconds(1);
        GameManager.instance.ReloadAnimation();
    }

    public void ParentCamera()
    {
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.Follow = transform;
        theVirtualCamera.transform.position = camPos.position;
        theVirtualCamera.transform.rotation = camPos.rotation;
        theVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(-4.31f, 0.66f, 1.12f);
        
    }



}
