using UnityEngine;
using Cinemachine;

public class RunningGame : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] CharacterRunCallback characterRunCallback;

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
        
        GameObject theCharacter = Instantiate(GameManager.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        characterRunCallback.SetCharacterRunScript(theCharacter.GetComponent<CharacterRunScript>());
        theCharacter.GetComponent<CharacterRunScript>().ParentCamera();

    }


}
