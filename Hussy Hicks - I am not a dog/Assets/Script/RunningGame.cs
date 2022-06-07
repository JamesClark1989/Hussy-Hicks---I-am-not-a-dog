using UnityEngine;
using Cinemachine;
using System.Collections;

public class RunningGame : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;
    [SerializeField] GameObject theCharacter;

    void Start()
    {
        SetUpGame();
        SpawnCharacter();
    }

    void SetUpGame()
    {
        GameManager.instance.SetSpawnPoint(spawnPoint);
        
    }

    public void SpawnCharacter()
    {
        
        theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
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



}
