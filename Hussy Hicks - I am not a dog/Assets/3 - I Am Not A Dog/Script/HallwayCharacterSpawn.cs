using UnityEngine;

public class HallwayCharacterSpawn : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] Transform spawnPos;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamera.SetActive(false);
        GameObject character = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), transform.position, transform.rotation);
        character.GetComponent<CharacterRunScript>().enabled = false;
        character.GetComponent<CharacterAnimationOnly>().enabled = true;
        character.GetComponent<CharacterAnimationOnly>().RunAnimation();

        character.transform.SetParent(transform);
    }

   
}
