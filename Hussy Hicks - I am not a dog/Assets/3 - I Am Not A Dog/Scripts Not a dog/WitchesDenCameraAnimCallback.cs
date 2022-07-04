using UnityEngine;

public class WitchesDenCameraAnimCallback : MonoBehaviour
{
    [SerializeField] WitchGameScript witchGameScript;
    public void StartGame()
    {
        witchGameScript.StartGameLoop();
    }

    public void Idle()
    {
        witchGameScript.CharacterIdle();
    }
}
