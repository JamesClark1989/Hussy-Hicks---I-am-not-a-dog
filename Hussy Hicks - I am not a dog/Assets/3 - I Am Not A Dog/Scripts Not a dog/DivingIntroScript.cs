using UnityEngine;

public class DivingIntroScript : MonoBehaviour
{
    [SerializeField] DivingGame divingGame;

    public void FinishedIntro()
    {
        divingGame.StartDiving();
    }
}
