using UnityEngine;

public class MainMenuTimelines : MonoBehaviour
{

    [SerializeField] GameObject[] timelines;


    public void PlayNextTimeline(int timelineElementNumber)
    {
        
        for (int i = 0; i < timelines.Length; i++)
        {
            timelines[i].SetActive(false);
        }

        timelines[timelineElementNumber].SetActive(true);
    }
}
