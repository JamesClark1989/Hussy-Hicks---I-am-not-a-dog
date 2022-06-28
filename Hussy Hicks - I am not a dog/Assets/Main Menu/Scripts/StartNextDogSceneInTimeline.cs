using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextDogSceneInTimeline : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void LoadTheNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
