using System.Collections;
using Cinemachine;
using UnityEngine;
using TMPro;

public class QuickDrawGame : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;

    [SerializeField] Animator cowboyAnim;

    [SerializeField] Transform cameraPos;

    [SerializeField] bool draw = false;
    [SerializeField] float drawTimer;
    [SerializeField] float drawTimerMax;
    bool haveNotShot = true;

    [SerializeField] float countDownTimer;
    [SerializeField] float countDownTimerMax;

    [SerializeField] GameObject drawButton;

    [SerializeField] TMP_Text counterText;

    void Start()
    {
        SetupGame();
    }

    public void SetupGame()
    {
        SpawnCharacter();
        cowboyAnim.Play("Quick Draw Idle");
        drawTimerMax = Random.Range(0.3f, 0.45f);
        drawTimer = drawTimerMax;

        countDownTimer = countDownTimerMax;
        haveNotShot = true;


        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
    }


    void Update()
    {
        if (haveNotShot)
        {
            if (draw)
            {
                drawButton.SetActive(true);
                drawTimer -= Time.deltaTime;
                if (drawTimer <= 0)
                {
                    cowboyAnim.SetTrigger("Draw");
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

    public void SpawnCharacter()
    {
        GameManager.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        characterRunCallback.SetCharacterRunScript(theCharacter.GetComponent<CharacterRunScript>());

        characterRunCallback.Run();

    }

    private IEnumerator FinishSection()
    {
        yield return new WaitForSeconds(1);
        characterRunCallback.Run();
    }

    public void CharacterShootFirst()
    {
        cowboyAnim.SetBool("Dead", true);
        cowboyAnim.ResetTrigger("Draw");
        cowboyAnim.GetComponent<CowboyScript>().CantShoot();
        haveNotShot = false;
        StartCoroutine("FinishSection");
    }

}
