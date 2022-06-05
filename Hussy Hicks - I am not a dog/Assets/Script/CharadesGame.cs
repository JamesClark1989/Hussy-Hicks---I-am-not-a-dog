using System.Collections;
using Cinemachine;
using UnityEngine;
using TMPro;

public class CharadesGame : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;

    [SerializeField] string answer;
    [SerializeField] TMP_Text[] answerButtons;

    [SerializeField] Animator bridgeAnim;
    [SerializeField] Animator bootAnim;
    [SerializeField] Animator monkeyAnim;

    [SerializeField] Transform cameraPos;

    string[] incorrectAnswers = { "Duck", "Car" };

    string[] correctAnswers = { "Kettle", "Balloon", "Scissors", "Rocking Chair" };

    void Start()
    {
        SpawnCharacter();
        SetUpCharadesGame();
    }


    private IEnumerator CorrectAnswer()
    {
        monkeyAnim.SetBool("Finished", true);
        bridgeAnim.SetBool("Raise", true);
        yield return new WaitForSeconds(1f);
        characterRunCallback.Run();
    }

    private IEnumerator IncorrectAnswer()
    {
        bootAnim.SetTrigger("Kick");
        yield return new WaitForSeconds(0.1f);
        characterRunCallback.RunSetSpeed(-7);
    }

    public void SpawnCharacter()
    {
        GameManager.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        characterRunCallback.SetCharacterRunScript(theCharacter.GetComponent<CharacterRunScript>());
    }


    public void SetUpCharadesGame()
    {
        // Setup Monkey
        answer = correctAnswers[Random.Range(0, correctAnswers.Length)];
        monkeyAnim.SetBool(answer, true);

        // Randomise answers
        float leftButtonIsAnswer = Random.Range(1, 10);
        if(leftButtonIsAnswer > 5)
        {
            answerButtons[0].SetText(answer);
            answerButtons[1].SetText(incorrectAnswers[Random.Range(0, incorrectAnswers.Length)]);
        }
        else
        {
            answerButtons[1].SetText(answer);
            answerButtons[0].SetText(incorrectAnswers[Random.Range(0, incorrectAnswers.Length)]);
        }

        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
        

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

}
