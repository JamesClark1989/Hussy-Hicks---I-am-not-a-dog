using UnityEngine;
using UnityEngine.SceneManagement;

public class DogReplayMenu : MonoBehaviour
{
    [SerializeField] string replay;
    [SerializeField] string menu;

    public void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }

    public void Replay()
    {
        SceneManager.LoadScene(replay);
    }
}
