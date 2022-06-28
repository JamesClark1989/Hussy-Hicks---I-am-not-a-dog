using System.Collections;
using Cinemachine;
using UnityEngine;
using TMPro;

public class CharadesGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;

    [SerializeField] string answer;
    [SerializeField] TMP_Text[] answerButtons;

    [SerializeField] Animator bridgeAnim;
    [SerializeField] Animator bootAnim;
    [SerializeField] Animator monkeyAnim;
    [SerializeField] Animator whirlwindAnim;

    [SerializeField] GameObject charadesAnswers;
    [SerializeField] GameObject ui;

    [SerializeField] Transform cameraPos;

    [SerializeField] int gameCounter;

    string[] incorrectAnswers = { "Duck", "Car", "Dog", "Lamp" };

    string[] correctAnswers = { "Kettle", "Balloon", "Scissors", "Rocking Chair" };

    void Start()
    {
        SpawnCharacter();
        SetUpCharadesGame();
    }


    private IEnumerator CorrectAnswer()
    {

        gameCounter++;
        if (gameCounter >= 2)
        {
            GameManagerDog.instance.SavedCurrentHussyHick(true);
            monkeyAnim.SetBool("Finished", true);
            bridgeAnim.SetBool("Raise", true);
            yield return new WaitForSeconds(1f);
            characterRunCallback.Run();
        }
        else
        {
            monkeyAnim.SetBool("Finished", true);
            yield return new WaitForSeconds(2f);
            ResetGame();
        }
    }

    public void ResetGame()
    {
        monkeyAnim.SetBool("Kettle", false);
        monkeyAnim.SetBool("Balloon", false);
        monkeyAnim.SetBool("Scissors", false);
        monkeyAnim.SetBool("Rocking Chair", false);

        monkeyAnim.SetBool("Finished", false);
        monkeyAnim.SetTrigger("Go Again");
        SetUpCharadesGame();
    }

    private IEnumerator IncorrectAnswer()
    {
        bootAnim.SetTrigger("Kick");
        yield return new WaitForSeconds(0.1f);
        characterRunCallback.RunSetSpeed(-7);
        monkeyAnim.SetBool("Finished", true);
        yield return new WaitForSeconds(2f);
        ResetGame();
    }

    public void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        characterRunCallback.SetCharacterRunScript(theCharacter.GetComponent<CharacterRunScript>());
    }


    public void SetUpCharadesGame()
    {
        SetupMonkey();

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;       

    }

    public void SetupMonkey()
    {

        answer = correctAnswers[Random.Range(0, correctAnswers.Length)];
        monkeyAnim.SetBool(answer, true);

    }

    public void SetupAnswerButtons()
    {
        // Randomise answers
        float leftButtonIsAnswer = Random.Range(1, 10);
        if (leftButtonIsAnswer > 5)
        {
            answerButtons[0].SetText(answer);
            answerButtons[1].SetText(incorrectAnswers[Random.Range(0, incorrectAnswers.Length)]);
        }
        else
        {
            answerButtons[1].SetText(answer);
            answerButtons[0].SetText(incorrectAnswers[Random.Range(0, incorrectAnswers.Length)]);
        }
    }

    public void CheckAnswer(TMP_Text selectedAnswer)
    {
        if(selectedAnswer.text != answer)
        {
            StartCoroutine("IncorrectAnswer");
        }
        else
        {
            StartCoroutine("CorrectAnswer");
        }
    }
    public void EndGameFunction()
    {
        ui.SetActive(false);
    }


    public void WonMiniGame()
    {

    }

    public void LostMiniGame()
    {

    }

}
