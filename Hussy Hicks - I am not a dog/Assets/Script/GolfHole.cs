using UnityEngine;

public class GolfHole : MonoBehaviour
{

    [SerializeField] GolfGame golfGame;
    [SerializeField] GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Golf Ball"))
        {
            golfGame.WonGame();
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
