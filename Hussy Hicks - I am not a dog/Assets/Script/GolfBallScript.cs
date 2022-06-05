using UnityEngine;
using System.Collections;

public class GolfBallScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force;

    [SerializeField] GameObject arrow;

    [SerializeField] bool hitTest = false;
    [SerializeField] bool putting = true;

    [SerializeField] float positiveRotation;
    [SerializeField] float negativeRotation;
    [SerializeField] float rotationSpeed;
    [SerializeField] Vector3 EulerAngleVelocity;

    [SerializeField] GolfGame golfGame;



    void Start()
    {
        EulerAngleVelocity = new Vector3(0, rotationSpeed,0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTest)
        {
            HitBall();
            hitTest = false;
        }
        
        if (putting)
        {
            RotateBackAndForth();
        }
        
    }


    void RotateBackAndForth()
    {
        if (transform.localRotation.y >= .35f) 
        {
            rotationSpeed = negativeRotation;
            EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
        } 
        else if (transform.localRotation.y <= -.35f)
        {
            rotationSpeed = positiveRotation;
            EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);

        }


        
        Quaternion deltaRotation = Quaternion.Euler(EulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public void HitBall()
    {
        putting = false;
        arrow.SetActive(false);
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        StartCoroutine("CountDownTillDeath");
    }

    private IEnumerator CountDownTillDeath()
    {
        yield return new WaitForSeconds(3);
        golfGame.StartGame();
        Destroy(gameObject);
    }

    public void SetGolfGameScript(GolfGame golfGameScript)
    {
        golfGame = golfGameScript;
    }
}
