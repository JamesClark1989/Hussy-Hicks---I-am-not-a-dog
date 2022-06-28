using UnityEngine;
using Cinemachine;
using System.Collections;

public class RunningGame : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;
    [SerializeField] GameObject theCharacter;
    [SerializeField] GameObject ui;

    void Start()
    {
        SetUpGame();
        SpawnCharacter();
    }

    void SetUpGame()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        
    }

    public void SpawnCharacter()
    {
        
        theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        Destroy(theCharacter.GetComponent<CharacterJumpController>());
        CharacterRunScript characterRunScript = theCharacter.GetComponent<CharacterRunScript>();
        characterRunCallback.SetCharacterRunScript(characterRunScript);
        characterRunScript.ParentCamera();
        characterRunScript.SetupRunningGameScript(this);

    }

    public void ChangeSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void RespawnPlayer()
    {
        theCharacter.SetActive(false);
        StartCoroutine("RespawnPlayerDelay");
    }

    private IEnumerator RespawnPlayerDelay()
    {
        yield return new WaitForSeconds(1);
        // play fade animation
        theCharacter.transform.position = spawnPoint.position;

        theCharacter.SetActive(true);


    }

    public void EndGameFunction()
    {
        Destroy(ui);
    }

    public void WonMiniGame()
    {

    }

    public void LostMiniGame()
    {

    }



}
