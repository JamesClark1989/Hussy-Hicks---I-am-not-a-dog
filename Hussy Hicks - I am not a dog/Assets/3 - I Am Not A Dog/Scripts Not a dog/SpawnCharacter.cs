using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    
    void Start()
    {
        Instantiate(GameManagerDog.instance.GetCurrentCharacter());
    }


}
