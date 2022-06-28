using System.Collections;
using UnityEngine;

public class ScorpionHitController : MonoBehaviour
{

    [SerializeField] ScorpionController scorpionController;
    public void Hit()
    {

        StartCoroutine("ScorpionPause");
    }

    private IEnumerator ScorpionPause()
    {
        scorpionController.PauseBattling();
        yield return new WaitForSeconds(1f);
        scorpionController.ContinueBattling();
    }
}
