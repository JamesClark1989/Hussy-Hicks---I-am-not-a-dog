
using UnityEngine;

public class SpawnPointUpdaterRunGame : MonoBehaviour
{
    [SerializeField] RunningGame runningGame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            runningGame.ChangeSpawnPoint(transform);
        }
    }
}
