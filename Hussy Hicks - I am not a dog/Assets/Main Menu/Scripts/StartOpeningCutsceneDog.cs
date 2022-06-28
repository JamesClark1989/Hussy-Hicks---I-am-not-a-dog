using UnityEngine;

public class StartOpeningCutsceneDog : MonoBehaviour
{

    [SerializeField] GameObject nexttimeline;

    public void NextTimeline()
    {
        nexttimeline.SetActive(true);
        gameObject.SetActive(false);
    }
}
