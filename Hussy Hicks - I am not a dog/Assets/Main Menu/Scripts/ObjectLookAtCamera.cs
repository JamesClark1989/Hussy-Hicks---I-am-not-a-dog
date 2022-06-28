using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        target = FindObjectOfType<Camera>().transform;
    }

    void Update()
    {

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 100, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
