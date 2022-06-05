using UnityEngine;
using System.Collections;
using Cinemachine;

public class GolfGame : MonoBehaviour
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

    void Start()
    {
        SetupGolfGame();
        SpawnCharacter();
    }

    void SetupGolfGame()
    {
        Transform startHolePos = holePositions[Random.Range(0, holePositions.Length)];
        golfHole.position = startHolePos.position;

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
        theVirtualCamera.transform.SetParent(cameraPos);

    }

    public void SpawnCharacter()
    {
        GameManager.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
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
        GameObject theGolfBall = Instantiate(golfBall, golfBallSpawnPos.position, golfBallSpawnPos.rotation);
        golfBallScript = theGolfBall.GetComponent<GolfBallScript>();
        golfBallScript.SetGolfGameScript(this);
        puttButton.SetActive(true);

        // Particles
        Instantiate(particle1, golfBallSpawnPos.position, golfBallSpawnPos.rotation);
    }

    public void HitBall()
    {
        golfBallScript.HitBall();
        characterAnimator.SetTrigger("Golf Putt");
        puttButton.SetActive(false);
    }

    public void WonGame()
    {
        characterAnimator.SetBool("Golf Idle", false);
        characterAnimator.SetBool("Celebrate", true);
        cameraAnimator.SetBool("Won", true);
        gateAnim.SetBool("Finished", true);
        crowd1.SetBool("Clap", true);
        crowd2.SetBool("Celebrate", true);

        StartCoroutine("WaitToFinish");
    }

    private IEnumerator WaitToFinish()
    {
        yield return new WaitForSeconds(2);
        UnparentCamera();
        GameManager.instance.LoadNewLevel();
    }

    public void UnparentCamera()
    {
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.SetParent(null);
    }

}
