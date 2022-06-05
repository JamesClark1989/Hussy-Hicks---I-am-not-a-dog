using UnityEngine;

public class TriggerGolfAnimation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterAnimationOnly>().PuttingIdle();
        }
    }
}
