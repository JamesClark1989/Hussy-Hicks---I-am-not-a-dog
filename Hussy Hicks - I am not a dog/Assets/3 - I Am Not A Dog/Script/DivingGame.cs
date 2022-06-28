using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DivingGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] GameObject ui;

    [SerializeField] Transform cameraPos;
    [SerializeField] Transform spawnPoint;

    [SerializeField] DivingScoreCardNumbers[] divingScoreCardNumbers;

    // Crowd Score Cards
    [SerializeField] GameObject[] scoreCards;

    // Animators
    [SerializeField] CharacterAnimationOnly characterAnimationOnly;
    [SerializeField] Animator characterParentAnimator;
    [SerializeField] Animator[] judgeAnimators;
    [SerializeField] Animator blackFadeAnim;

    [SerializeField] int gameCounter = 0;

    [SerializeField] bool startGame = false;


    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] bool gameEnded = false;

    [SerializeField] GameObject divingCanvas;

    // Sliding Time
    [SerializeField] Slider answerSlider;
    [SerializeField] Slider setSlider;
    [SerializeField] float sliderSpeed;

    float speed = 1;

    void Start()
    {
        SetupGame();
        SpawnCharacter();
        SetupRotationRange();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (answerSlider.value >= 1)
                sliderSpeed = -speed;
            else if (answerSlider.value <= 0)
                sliderSpeed = speed;

            answerSlider.value += Time.deltaTime * sliderSpeed;
        }
    }

    void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        theCharacter.transform.SetParent(spawnPoint);
        theCharacter.GetComponent<CharacterRunScript>().enabled = false;
        theCharacter.GetComponent<CharacterController>().enabled = false;
        characterAnimationOnly = theCharacter.GetComponent<CharacterAnimationOnly>();
        characterAnimationOnly.enabled = true;
        characterAnimationOnly.RunAnimation();

    }

    void SetupGame()
    {
        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
        theVirtualCamera.transform.SetParent(cameraPos);
    }

    void SetupRotationRange()
    {
        setSlider.value = Random.Range(0f, 1f);

        ui.SetActive(false);
    }

    public void CheckAnswer()
    {

        float answer = answerSlider.value;

        if (answer <= setSlider.value + 0.08f && answer >= setSlider.value - 0.08f)
        {
            StartCoroutine("DivedCorrect");
        }
        else
        {
            StartCoroutine("DiveFailed");
        }

        startGame = false;
    }

    private IEnumerator DiveFailed()
    {
        characterParentAnimator.SetTrigger("Fall");
        characterAnimationOnly.DiveFail();

        yield return new WaitForSeconds(0.5f);

        if (gameEnded == false)
        {
            yield return new WaitForSeconds(1.5f);

            // Judges score low

            for (int i = 0; i < judgeAnimators.Length; i++)
            {
                judgeAnimators[i].SetTrigger("Score");
                scoreCards[i].SetActive(true);
                divingScoreCardNumbers[i].TurnOnNumbers(false);
            }

            yield return new WaitForSeconds(1.4f);
            blackFadeAnim.SetTrigger("Reset");

            SetupRotationRange();

        }


    }


    private IEnumerator DivedCorrect()
    {

        // add to score
        speed += 1;
        gameCounter += 1;
        score += 10;
        scoreText.SetText("Score: " + score.ToString());
        CheckGameCounter();

        characterAnimationOnly.DiveCorrect();
        characterParentAnimator.SetTrigger("Dive");
        yield return new WaitForSeconds(0.5f);


        if(gameEnded == false)
        {

            ui.SetActive(false);

            yield return new WaitForSeconds(1.5f);

            for (int i = 0; i < judgeAnimators.Length; i++)
            {
                judgeAnimators[i].SetTrigger("Score");
                scoreCards[i].SetActive(true);
                divingScoreCardNumbers[i].TurnOnNumbers(true);
            }
            yield return new WaitForSeconds(1.4f);
            blackFadeAnim.SetTrigger("Reset");

            SetupRotationRange();


        }

    }

    void CheckGameCounter()
    {
        if(gameCounter >= 2)
        {
            GameManagerDog.instance.SavedCurrentHussyHick(true);
        }
    }

    public void StartDiving()
    {

        characterAnimationOnly.DivingIdle();
        ui.SetActive(true);
        startGame = true;

    }

    public void StartNextGame()
    {
        // Reset judges
        for (int i = 0; i < judgeAnimators.Length; i++)
        {
            judgeAnimators[i].SetTrigger("Reset");
            divingScoreCardNumbers[i].TurnOffNumbers();
            scoreCards[i].SetActive(false);
        }

        // Reset Character
        
        characterParentAnimator.SetTrigger("Restart");
        characterAnimationOnly.BackToIdle();

        StartCoroutine("DelayBeforeUIReappears");
    }

    private IEnumerator DelayBeforeUIReappears()
    {
        yield return new WaitForSeconds(1.5f);

        ui.SetActive(true);
        startGame = true;
    }

    public void EndGameFunction() 
    {
        Destroy(divingCanvas);
        gameEnded = true;
        if (score >= 20)
        {
            WonMiniGame();
        }
        else
        {
            LostMiniGame();
        }
    }

    public void WonMiniGame()
    {
        characterAnimationOnly.CelebratePuttWin();
    }

    public void LostMiniGame()
    {
        characterAnimationOnly.Scared();
    }
}
