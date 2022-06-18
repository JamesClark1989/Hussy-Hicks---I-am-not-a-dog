using System.Collections;
using Cinemachine;
using UnityEngine;
using TMPro;

public class QuickDrawGame : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterDrawCallback characterDrawCallback;
    [SerializeField] CowboyScript cowboyScript;

    [SerializeField] Animator cowboyAnim;
    [SerializeField] Animator fadeAnim;
    [SerializeField] Animator characterAnim;
    [SerializeField] Animator wonGameAnimator;

    [SerializeField] Transform cameraPos;

    [SerializeField] bool draw = false;
    [SerializeField] float drawTimer;
    [SerializeField] float drawTimerMax;
    bool haveNotShot = false;

    [SerializeField] float countDownTimer;
    [SerializeField] float countDownTimerMax;

    [SerializeField] GameObject drawButton;

    [SerializeField] TMP_Text counterText;

    [SerializeField] int roundCounter = 1;
    [SerializeField] TMP_Text roundText;
    [SerializeField] Animator roundTextAnim;

    [SerializeField] bool drawButtonShowing = false;

    void Start()
    {
        SetupGame();
    }

    public void SetRoundText()
    {
        roundText.SetText("Round " + roundCounter.ToString());
    }

    public void SetupGame()
    {
        SpawnCharacter();

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
    }

    public void ResetGame()
    {
        if(roundCounter < 4)
        {
            SetRoundText();
            roundTextAnim.SetTrigger("ShowText");
            cowboyAnim.SetBool("Dead", false);
            cowboyAnim.Play("Quick Draw Idle");

            characterAnim.SetTrigger("Quick Draw");
            characterAnim.SetBool("Lost Draw", false);
            StartCoroutine("ShowRoundText");
        }
        else
        {
            // Win Condition!!!
            print("WIN!");
        }

    }

    private IEnumerator ShowRoundText()
    {
        yield return new WaitForSeconds(2.5f);

        drawButtonShowing = false;

        //cowboyScript.CanShoot();

        draw = false;
        drawButton.SetActive(false);


        drawTimerMax = Random.Range(0.35f, 0.45f);
        drawTimer = drawTimerMax;

        countDownTimer = countDownTimerMax;
        haveNotShot = true;


    }


    void Update()
    {
        if (haveNotShot)
        {
            if (draw)
            {
                // Some dodgy code. Should've been done in animator
                if(drawButtonShowing == false)
                {
                    drawButton.SetActive(true);
                    drawButtonShowing = true;
                }
                drawTimer -= Time.deltaTime;
                if (drawTimer <= 0)
                {
                    cowboyAnim.SetTrigger("Draw");
                    haveNotShot = false;
                    draw = false;
                    fadeAnim.SetTrigger("Reset");
                }
            }
            else
            {
                countDownTimer -= Time.deltaTime;
                counterText.SetText(((int)Mathf.Ceil(countDownTimer)).ToString());
                if (countDownTimer <= 0)
                {
                    draw = true;
                    counterText.SetText("");
                }
            }
        }

    }

    void FinishGame()
    {
        draw = false;
        drawButton.SetActive(false);
        GameManager.instance.SavedCurrentHussyHick(true);
        wonGameAnimator.SetBool("Won", true);
    }

    public void SpawnCharacter()
    {
        //GameManager.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.position, spawnPoint.rotation);

        // Fuck the shit components off
        Destroy(theCharacter.GetComponent<CharacterRunScript>());
        Destroy(theCharacter.GetComponent<CharacterController>());

        characterAnim = theCharacter.GetComponent<Animator>();

        // Set the draw script on the callback script
        characterDrawCallback.SetCharacterDrawScript(theCharacter.GetComponent<CharacterDrawGameScript>());
        characterDrawCallback.SetQuickDrawGameScript(this);
        characterDrawCallback.Run();

        theCharacter.transform.SetParent(spawnPoint);


    }

    public void CharacterShootFirst()
    {
        drawButton.SetActive(false);
        cowboyAnim.SetBool("Dead", true);
        cowboyAnim.ResetTrigger("Draw");
        //cowboyAnim.GetComponent<CowboyScript>().CantShoot();
        roundCounter++;
        haveNotShot = false;
    }

}
