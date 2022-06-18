using System.Collections;
using TMPro;
using UnityEngine;
using Cinemachine;

public class DivingGame : MonoBehaviour
{
    [SerializeField] RectTransform easy;
    [SerializeField] RectTransform medium;
    [SerializeField] RectTransform hard;
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

    [SerializeField] RectTransform pointer;
    [SerializeField] Vector3 pointerRot;
    [SerializeField] float pointerSpeed;
    float pointerSpeedPositive = 180;
    float pointerSpeedNegative = -180;
    [SerializeField] float maxPointerRotation;

    [SerializeField] int gameCounter = 0;

    [SerializeField] bool startGame = false;

    [SerializeField] float currentCorrectRotation;
    [SerializeField] float correctRotationExtra;

    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        SetupGame();
        SpawnCharacter();
        easy.eulerAngles = new Vector3(0,0,Random.Range(-75, 75));
        SetupRotationRange();
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (pointerRot.z >= maxPointerRotation) pointerSpeed = pointerSpeedNegative;
            else if (pointerRot.z <= -maxPointerRotation) pointerSpeed = pointerSpeedPositive;
            pointerRot.z += pointerSpeed * Time.deltaTime;
            pointer.eulerAngles = pointerRot;
        }
    }

    void SpawnCharacter()
    {
        GameManager.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
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
    }

    void SetupRotationRange()
    {

        if(gameCounter == 0)
        {
            currentCorrectRotation = easy.eulerAngles.z;
            correctRotationExtra = 26;
        }
        else if (gameCounter == 1)
        {
            currentCorrectRotation = medium.eulerAngles.z;
            correctRotationExtra = 14;
        }
        else if (gameCounter == 2)
        {
            currentCorrectRotation = hard.eulerAngles.z;
            correctRotationExtra = 5;
        }
    }

    public void CheckAnswer(RectTransform rotationAnswer)
    {
        float selectedRotation = rotationAnswer.eulerAngles.z;

        if(selectedRotation <= currentCorrectRotation + correctRotationExtra && selectedRotation >= currentCorrectRotation - correctRotationExtra)
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

        if(gameCounter > 0)
            gameCounter -= 1;

        // Deactivate all difficulty ui
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);

        if (gameCounter == 0)
        {
            easy.gameObject.SetActive(true);
            easy.eulerAngles = new Vector3(0, 0, Random.Range(-75, 75));
            SetupRotationRange();
        }
        else if (gameCounter == 1)
        {
            medium.gameObject.SetActive(true);
            medium.eulerAngles = new Vector3(0, 0, Random.Range(-75, 75));
            SetupRotationRange();
        }
        else if (gameCounter == 2)
        {
            hard.gameObject.SetActive(true);
            hard.eulerAngles = new Vector3(0, 0, Random.Range(-85, 85));
            SetupRotationRange();
        }

        ui.SetActive(false);



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


    }


    private IEnumerator DivedCorrect()
    {
        characterAnimationOnly.DiveCorrect();
        characterParentAnimator.SetTrigger("Dive");
        yield return new WaitForSeconds(0.5f);

        // Deactivate all difficulty ui
        easy.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        hard.gameObject.SetActive(false);


        if(gameCounter < 2)
            gameCounter += 1;

        if(gameCounter == 0)
        {
            easy.gameObject.SetActive(true);
            easy.eulerAngles = new Vector3(0, 0, Random.Range(-75, 75));
            SetupRotationRange();
        }
        else if (gameCounter == 1)
        {
            medium.gameObject.SetActive(true);
            medium.eulerAngles = new Vector3(0, 0, Random.Range(-75, 75));
            SetupRotationRange();
        }
        else if (gameCounter == 2)
        {
            hard.gameObject.SetActive(true);
            hard.eulerAngles = new Vector3(0, 0, Random.Range(-85, 85));
            SetupRotationRange();
        }
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

        // add to score
        score += 10;
        scoreText.SetText("Score: " + score.ToString());

    }

    public int CheckGameCounter()
    {
        return gameCounter;
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
}
