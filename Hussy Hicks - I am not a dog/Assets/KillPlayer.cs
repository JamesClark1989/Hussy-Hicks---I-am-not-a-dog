using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] Animator fadeAnim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            fadeAnim.SetTrigger("Reset");
        }
    }
}
