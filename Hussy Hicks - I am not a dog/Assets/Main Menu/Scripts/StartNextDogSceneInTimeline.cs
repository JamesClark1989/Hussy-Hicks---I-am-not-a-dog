using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNextDogSceneInTimeline : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingProgressBar;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    public void LoadTheNextScene()
    {
        loadingScreen.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Mini Games Scene"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Hussy Hack Battle", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Dungeon Ending", LoadSceneMode.Additive));
        StartCoroutine(LoadingScreen());
        //SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;
        for(int i = 0; i < scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgressBar.value = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }
}
