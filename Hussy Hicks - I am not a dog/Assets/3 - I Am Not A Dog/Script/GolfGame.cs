using UnityEngine;
using TMPro;
using System.Collections;
using Cinemachine;

public class GolfGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] Transform[] holePositions;
    [SerializeField] Transform golfHole;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform cameraPos;
    [SerializeField] Transform golfBallSpawnPos;

    [SerializeField] Animator cameraAnimator;
    [SerializeField] Animator characterAnimator;
    [SerializeField] Animator gateAnim;
    [SerializeField] Animator crowd1;
    [SerializeField] Animator crowd2;

    [SerializeField] GameObject golfClub;
    [SerializeField] GameObject golfBall;
    [SerializeField] GameObject puttButton;
    [SerializeField] GameObject particle1;

    [SerializeField] GolfBallScript golfBallScript;

    [SerializeField] CharacterAnimationOnly characterAnimationOnly;

    [SerializeField] int score = 0;
    [SerializeField] int currentHole;
    [SerializeField] TMP_Text scoreText;

    [SerializeField] bool wonGame = false;

    void Start()
    {
        SetupGolfGame();
        SpawnCharacter();
    }

    void SetupGolfGame()
    {
        SetHolePosition();

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
        theVirtualCamera.transform.SetParent(cameraPos);

    }

    public void SetHolePosition()
    {
        if(wonGame == false)
        {

            Transform startHolePos = holePositions[Random.Range(0, holePositions.Length)];
            golfHole.position = startHolePos.position;
        }
    }

    public void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        theCharacter.transform.SetParent(spawnPoint);
        theCharacter.GetComponent<CharacterRunScript>().enabled = false;
        characterAnimationOnly = theCharacter.GetComponent<CharacterAnimationOnly>();
        characterAnimationOnly.enabled = true;
        characterAnimationOnly.RunAnimation();

        characterAnimator = theCharacter.GetComponent<Animator>();


        Transform itemPos = theCharacter.GetComponent<CharacterItemLocation>().GetItemPosition();
        GameObject golfClubObject = Instantiate(golfClub, itemPos.position, itemPos.rotation);
        golfClubObject.transform.SetParent(itemPos);
    }

    public void StartGame()
    {
        if(wonGame == false)
        {
            GameObject theGolfBall = Instantiate(golfBall, golfBallSpawnPos.position, golfBallSpawnPos.rotation);
            golfBallScript = theGolfBall.GetComponent<GolfBallScript>();
            golfBallScript.SetGolfGameScript(this);
            puttButton.SetActive(true);

            // Particles
            Instantiate(particle1, golfBallSpawnPos.position, golfBallSpawnPos.rotation);
        }

    }

    public void HitBall()
    {
        golfBallScript.HitBall();
        characterAnimator.SetTrigger("Golf Putt");
        puttButton.SetActive(false);
    }

    public void ChangeScore(int newScore)
    {
        score += newScore;
        scoreText.SetText("Score: " + score.ToString());
        if(score >=30)
        {
            GameManagerDog.instance.SavedCurrentHussyHick(true);
            WonMiniGame();
            wonGame = true;
        }
    }

    public void EndGameFunction()
    {
        if (wonGame)
        {
            WonMiniGame();
        }
        else
        {
            LostMiniGame();
        }
    }

    public void LostMiniGame()
    {
        Destroy(FindObjectOfType<GolfBallScript>().gameObject);
        Destroy(puttButton);
        characterAnimator.SetBool("Golf Idle", false);
        characterAnimator.SetBool("Scared", true);
        cameraAnimator.SetBool("Won", true);
        crowd1.SetBool("Clap", true);
        crowd2.SetBool("Celebrate", true);
    }

    public void WonMiniGame()
    {
        Destroy(FindObjectOfType<GolfBallScript>().gameObject);
        Destroy(puttButton);
        characterAnimator.SetBool("Golf Idle", false);
        characterAnimator.SetBool("Celebrate", true);
        cameraAnimator.SetBool("Won", true);
        gateAnim.SetBool("Finished", true);
        crowd1.SetBool("Clap", true);
        crowd2.SetBool("Celebrate", true);

    }



}
