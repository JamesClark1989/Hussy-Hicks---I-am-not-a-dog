using UnityEngine;

public class CrowdDanceAnimations : MonoBehaviour
{
    [SerializeField] Animator[] crowdAnims;


    private void OnEnable()
    {
        // Shuffle anims
        for (int i = 0; i < crowdAnims.Length; i++)
        {
            Animator tmp = crowdAnims[i];
            int r = Random.Range(i, crowdAnims.Length);
            crowdAnims[i] = crowdAnims[r];
            crowdAnims[r] = tmp;
        }

        // Set Dances
        for (int i = 0; i < crowdAnims.Length; i++)
        {
            int danceNum = i + 1;
            crowdAnims[i].SetTrigger("Dance " + danceNum.ToString());
        }
    }
}
