using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadMiniGameCallback : MonoBehaviour
{

    //[SerializeField] RectTransform timerBar;
    [SerializeField] float timer;
    [SerializeField] float timerMax;
    //[SerializeField] Vector2 barWidth;

    [SerializeField] bool currentlyPlaying = false;

    [SerializeField] Slider timerRadial;


    [SerializeField] GameObject waitForTimer;

    private void Start()
    {
        //barWidth = timerBar.sizeDelta;
        timer = timerMax;
    }

    private void Update()
    {
        if (currentlyPlaying)
        {
            //float width = Mathf.MoveTowards(timerBar.sizeDelta.x, 0, timer * Time.deltaTime);
            //timerBar.sizeDelta = new Vector2(width, timerBar.sizeDelta.y);

            timerRadial.value = timer;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // This won't show fail text if the player has passed the game
                StartCoroutine("ShowFailText");
                currentlyPlaying = false;

                waitForTimer.SetActive(false);
            }
        }
    }

    public void DestroyCurrentMiniGame()
    {
        GameManagerDog.instance.DestroyMiniGame();
    }

    public void LoadHallway()
    {
        GameManagerDog.instance.LoadHallway();
    }

    public void LoadMiniGame()
    {
        GameManagerDog.instance.SpawnMiniGameRoom();
        //timerBar.sizeDelta = barWidth;
        timer = timerMax;
        currentlyPlaying = true;
        
    }

    private IEnumerator ShowFailText()
    {
        GameManagerDog.instance.SavedCurrentHussyHick(false);
        // Call end game function on mini game
        GameManagerDog.instance.TriggerMiniGameEndScene();
        GameManagerDog.instance.ShowSavedOrNotSavedText();
        GameManagerDog.instance.CurrentMiniGameFinished();
        // Might need to fade out
        yield return new WaitForSeconds(2.5f);
        GameManagerDog.instance.LoadNextLevel();
        GameManagerDog.instance.ChangeNextCharacter();
    }

    public void ShowWaitForTimer()
    {
        if(timer > 0)
        {
            waitForTimer.SetActive(true);
        }
    }


}
