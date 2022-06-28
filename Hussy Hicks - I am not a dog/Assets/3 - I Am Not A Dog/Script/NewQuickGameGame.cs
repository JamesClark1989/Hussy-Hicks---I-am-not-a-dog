
using Cinemachine;
using UnityEngine;
using TMPro;
public class NewQuickGameGame : MonoBehaviour, IEndOfMiniGame
{
    // Animators
    [SerializeField] Animator cowboyAnim;
    [SerializeField] Animator characterAnim;
    [SerializeField] Animator characterEnterExitAnim;
    [SerializeField] Animator RoundAnim;

    [SerializeField] GameObject ui;
    [SerializeField] GameObject drawui;

    [SerializeField] Transform cameraPos;
    [SerializeField] Transform spawnPoint;

    [SerializeField] bool wonGame = false;

    [SerializeField] CharacterDrawGameScript characterDrawGameScript;
    [SerializeField] CowboyScript cowboyScript;

    [SerializeField] TMP_Text roundText;

    [SerializeField] bool playerCanShoot = true;

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
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.position, spawnPoint.rotation);

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
        playerCanShoot = true;
        cowboyScript.SetToCanShoot();
    }

    void SetRoundText()
    {
        roundText.SetText("Round " + RoundCounter.ToString());
    }

    public void StartRoundCountdown()
    {
        if(wonGame == false)
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
        if (playerCanShoot)
        {
            cowboyScript.StopDraw();
            cowboyAnim.SetTrigger("Dead");
            RoundCounter++;
            SetRoundText();
        }


        if (RoundCounter == 4)
        {
            Won();
        }
        else
        {
            RoundAnim.SetTrigger("Restart");
        }
    }

    // Kill Player
    public void CowboyShoot()
    {
        playerCanShoot = false;
        characterAnim.SetBool("Lost Draw", true);
        drawui.SetActive(false);
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
        GameManagerDog.instance.SavedCurrentHussyHick(true);
        wonGame = true;
        characterDrawGameScript.Celebrate();

    }

    public void EndGameFunction()
    {
        Destroy(ui);
    }

    public void WonMiniGame()
    {

        cowboyAnim.SetTrigger("Dead");
    }

    public void LostMiniGame()
    {
    }
}
