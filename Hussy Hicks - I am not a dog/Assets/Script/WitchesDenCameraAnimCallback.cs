using UnityEngine;

public class WitchesDenCameraAnimCallback : MonoBehaviour
{
    [SerializeField] WitchGameScript witchGameScript;
    public void StartGame()
    {
        witchGameScript.StartGameLoop();
    }
}
