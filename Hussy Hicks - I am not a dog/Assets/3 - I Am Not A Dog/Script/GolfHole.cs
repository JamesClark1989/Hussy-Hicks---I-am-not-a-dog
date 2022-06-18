using UnityEngine;
using System.Collections;

public class GolfHole : MonoBehaviour
{

    [SerializeField] GolfGame golfGame;
    [SerializeField] GameObject particle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Golf Ball"))
        {
            //golfGame.WonGame();
            golfGame.ChangeScore(10);
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(other.gameObject);
            StartCoroutine("DelayBeforeReset");
        }
    }

    private IEnumerator DelayBeforeReset()
    {
        yield return new WaitForSeconds(2);
        golfGame.StartGame();
    }
}
