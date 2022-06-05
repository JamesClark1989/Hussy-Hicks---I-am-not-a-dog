using UnityEngine;

public class HallwayCharacterSpawn : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.SetActive(false);
        GameObject character = Instantiate(GameManager.instance.GetCurrentCharacter(), transform.position, transform.rotation);
        character.transform.SetParent(transform);
        character.GetComponent<CharacterRunScript>().Run();
    }

   
}
