using UnityEngine.Playables;
using UnityEngine;

public class ActivateObjectAfterTimeline : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject nextTimeline;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            nextTimeline.SetActive(true);
            transform.gameObject.SetActive(false);

        }
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
}
