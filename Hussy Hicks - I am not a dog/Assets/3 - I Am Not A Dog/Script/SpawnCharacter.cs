using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    
    void Start()
    {
        Instantiate(GameManager.instance.GetCurrentCharacter());
    }


}
