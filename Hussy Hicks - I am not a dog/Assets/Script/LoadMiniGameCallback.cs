using UnityEngine;
using System.Collections;

public class LoadMiniGameCallback : MonoBehaviour
{

    [SerializeField] RectTransform timerBar;
    [SerializeField] float timer;
    [SerializeField] float timerMax;
    [SerializeField] float barWidth;

    [SerializeField] bool currentlyPlaying = false;

    private void Start()
    {
        timer = timerMax;
    }

    private void Update()
    {
        if (currentlyPlaying)
        {
            float width = Mathf.MoveTowards(timerBar.sizeDelta.x, 0, timer * Time.deltaTime);
            timerBar.sizeDelta = new Vector2(width, timerBar.sizeDelta.y);
            if (width == 0)
            {
                GameManager.instance.LoadNextLevel();
                currentlyPlaying = false;
            }
        }
    }

    public void DestroyCurrentMiniGame()
    {
        GameManager.instance.DestroyMiniGame();
    }


    public void LoadHallway()
    {
        GameManager.instance.LoadHallway();
    }

    public void LoadMiniGame()
    {
        GameManager.instance.SpawnMiniGameRoom();
        StartCoroutine("WaitBeforeTimer");
    }

    private IEnumerator WaitBeforeTimer()
    {
        yield return new WaitForSeconds(1);
        timer = timerMax;
        currentlyPlaying = true;
    }
}
