using UnityEngine;

public class ScorpionGetHit : MonoBehaviour
{
    [SerializeField] ScorpionHitController scorpionHitController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scorpionHitController.Hit();
            other.GetComponent<CharacterJumpController>().Fall();
            gameObject.SetActive(false);
        }
    }


}
