using System.Collections;
using UnityEngine;
using Cinemachine;

public class CthuluGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] Animator TabletUIAnim;
    [SerializeField] Animator cthuluAnimator;
    [SerializeField] Animator gateAnimator;
    [SerializeField] Animator glowAnimator;

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform cameraPos;

    [SerializeField] int correctTabletsAmount = 0;

    private void Start()
    {
        SetupCthuluGame();
        SpawnCharacter();
    }

    void SetupCthuluGame()
    {
        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
    }

    public void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        theCharacter.GetComponent<CharacterRunScript>().enabled = false;
        theCharacter.transform.SetParent(spawnPoint);
        theCharacter.GetComponent<CharacterAnimationOnly>().RunAnimation();
    }

    public void StartGame()
    {
        TabletUIAnim.SetBool("StartGame", true);
    }
    public void IncreaseCorrectTabletsAmount()
    {
        correctTabletsAmount += 1;
        if (correctTabletsAmount == 6)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        TabletUIAnim.SetBool("EndGame", true);
        cthuluAnimator.SetBool("Alive", true);
        gateAnimator.SetBool("Finished", true);
        glowAnimator.SetBool("Finished", true);
        GameManagerDog.instance.SavedCurrentHussyHick(true);
        FindObjectOfType<LoadMiniGameCallback>().ShowWaitForTimer();
    }


    public void EndGameFunction()
    {

    }

    public void WonMiniGame()
    {

    }

    public void LostMiniGame()
    {

    }

}
