using UnityEngine.Playables;
using UnityEngine;

public class ChooseEndingDogGame : MonoBehaviour
{
    [SerializeField] PlayableDirector director;
    [SerializeField] GameObject goodEndingRegular;
    [SerializeField] GameObject goodEndingJulzLeesa;

    [SerializeField] CheckWhichHussyHicksLived checkWhichHussyHicksLived;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (director == aDirector)
        {
            if (checkWhichHussyHicksLived.CheckIfJulzAndLeesa())
            {
                goodEndingJulzLeesa.SetActive(true);
            }
            else
            {
                goodEndingRegular.SetActive(true);
            }
            transform.gameObject.SetActive(false);

        }
    }

    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
}
