using UnityEngine;

public class StopPlayerRunningTrigger : MonoBehaviour
{
    [SerializeField] CharacterRunCallback characterRunCallback;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            characterRunCallback.StopRunning();
            characterRunCallback.DrawReadyPosition();
            Destroy(gameObject);
        }
    }
}
