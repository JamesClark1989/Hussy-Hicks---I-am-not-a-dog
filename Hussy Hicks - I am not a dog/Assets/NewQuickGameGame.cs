using System.Collections;
using Cinemachine;
using UnityEngine;
using TMPro;
public class NewQuickGameGame : MonoBehaviour
{
    // Animators
    [SerializeField] Animator cowboyAnim;
    [SerializeField] Animator characterAnim;
    [SerializeField] Animator characterEnterExitAnim;
    [SerializeField] Animator RoundAnim;

    [SerializeField] GameObject drawButton;

    [SerializeField] Transform cameraPos;
    [SerializeField] Transform spawnPoint;

    [SerializeField] CharacterDrawGameScript characterDrawGameScript;
    [SerializeField] CowboyScript cowboyScript;

    [SerializeField] TMP_Text roundText;

    int RoundCounter = 1;

    void Start()
    {
        SetupGame();
        SetRoundText();
    } 

    void SetupGame()
    {
        SpawnCharacter();

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
    }

    void SpawnCharacter()
    {
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.position, spawnPoint.rotation);

        // Fuck the shit components off
        Destroy(theCharacter.GetComponent<CharacterRunScript>());
        Destroy(theCharacter.GetComponent<CharacterController>());

        characterAnim = theCharacter.GetComponent<Animator>();

        characterDrawGameScript = theCharacter.GetComponent<CharacterDrawGameScript>();
        characterDrawGameScript.enabled = true;
        characterDrawGameScript.RunAnimation();

        theCharacter.transform.SetParent(spawnPoint);
    }

    public void ResetGame()
    {
        cowboyAnim.SetTrigger("Idle");
        characterDrawGameScript.DrawIdleAnimation();
    }

    void SetRoundText()
    {
        roundText.SetText("Round " + RoundCounter.ToString());
    }

    public void StartRoundCountdown()
    {
        RoundAnim.SetBool("Countdown", true);
    }

    // As soon as you can draw, this calls the cowboy script to countdown before he draws
    public void DrawTime()
    {
        cowboyScript.Draw();
    }

    // This is called from the Draw animation in the Player Animator
    public void PlayerShoot()
    {
        cowboyScript.StopDraw();
        cowboyAnim.SetTrigger("Dead");
        RoundCounter++;
        if(RoundCounter < 4)
        {
            SetRoundText();
            RoundAnim.SetTrigger("Restart");
        }
        else
        {
            Won();
        }
    }

    // Kill Player
    public void CowboyShoot()
    {
       
        characterAnim.SetBool("Lost Draw", true);
        RoundAnim.SetTrigger("Restart");
    }


    // Play player draw animation
    public void PlayerDrawAnimation()
    {
        characterDrawGameScript.CharacterShootAnimation();
    }

    // Stop player running animation
    public void StopRunning()
    {
        characterDrawGameScript.DrawIdleAnimation();
    }

    // Win Game
    void Won()
    {
        GameManager.instance.SavedCurrentHussyHick(true);
    }
}
