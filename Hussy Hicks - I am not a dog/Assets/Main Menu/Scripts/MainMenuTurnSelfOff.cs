using UnityEngine;

public class MainMenuTurnSelfOff : MonoBehaviour
{

    [SerializeField] Animator mainMenuFadeAnim;

    public void FadeOut()
    {
        mainMenuFadeAnim.SetTrigger("Fade Out");
    }

    public void TurnSelfOff()
    {
        gameObject.SetActive(false);
    }
}
