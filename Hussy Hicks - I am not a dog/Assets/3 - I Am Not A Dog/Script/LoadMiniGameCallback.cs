using UnityEngine;
using System.Collections;

public class LoadMiniGameCallback : MonoBehaviour
{

    [SerializeField] RectTransform timerBar;
    [SerializeField] float timer;
    [SerializeField] float timerMax;
    [SerializeField] Vector2 barWidth;

    [SerializeField] bool currentlyPlaying = false;

    private void Start()
    {
        barWidth = timerBar.sizeDelta;
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
                // This won't show fail text if the player has passed the game
                StartCoroutine("ShowFailText");
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
        timerBar.sizeDelta = barWidth;
        timer = timerMax;
        currentlyPlaying = true;
    }

    private IEnumerator ShowFailText()
    {
        GameManager.instance.SavedCurrentHussyHick(false);
        yield return new WaitForSeconds(2);
        GameManager.instance.LoadNextLevel();
        GameManager.instance.ChangeNextCharacter();
    }


}
