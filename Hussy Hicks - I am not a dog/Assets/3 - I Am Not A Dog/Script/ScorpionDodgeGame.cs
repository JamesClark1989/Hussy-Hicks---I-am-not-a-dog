using System.Collections;
using Cinemachine;
using UnityEngine;

public class ScorpionDodgeGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterJumpController characterJumpController;
    [SerializeField] CharacterRunScript characterRunScript;
    [SerializeField] Animator platforms;
    [SerializeField] Transform cameraPos;
    [SerializeField] Transform finishRotation;
    [SerializeField] ScorpionController scorpionController;

    [SerializeField] GameObject finishGameCollider;

    [SerializeField] Vector3 jumpPosition1;
    [SerializeField] Vector3 jumpPosition2;

    [SerializeField] GameObject ui;

    bool wonGame = false;

    void Start()
    {
        SpawnCharacter();
        SetUpScorpionGame();
    }


    public void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        characterRunScript = theCharacter.GetComponent<CharacterRunScript>();
        characterRunScript.enabled = false;
        characterJumpController = theCharacter.GetComponent<CharacterJumpController>();
        characterJumpController.enabled = true;
    }


    public void SetUpScorpionGame()
    {
        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;

    }

    public void FinishedLevel()
    {
        ui.SetActive(false);
        GameManagerDog.instance.SavedCurrentHussyHick(true);
        wonGame = true;
        platforms.SetBool("Raise", true);
        finishGameCollider.SetActive(true);
        characterJumpController.transform.rotation = finishRotation.rotation;
        characterJumpController.enabled = false;
        characterRunScript.enabled = true;
        characterRunScript.Run();

    }

    public void EndGameFunction() 
    {
        ui.SetActive(false);
        if (!wonGame)
            LostMiniGame();
    }


    public void WonMiniGame()
    {

    }

    public void LostMiniGame()
    {
        scorpionController.StopBattlingBadEnd();

    }


}
