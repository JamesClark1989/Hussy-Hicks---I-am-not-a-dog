
using UnityEngine;

public class ScorpionDeathPit : MonoBehaviour
{
    [SerializeField] ScorpionHitController scorpionHitController;
    [SerializeField] Transform startPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterJumpController>().ReturnToStart(startPos);
            scorpionHitController.Hit();
        }
    }
}
