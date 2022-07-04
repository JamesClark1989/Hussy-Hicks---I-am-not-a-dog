using UnityEngine;

public class CharacterDrawGameScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] NewQuickGameGame newQuickDrawGame;

    private void Start()
    {
        newQuickDrawGame = FindObjectOfType<NewQuickGameGame>();
    }

    public void ShootCowboy()
    {
        newQuickDrawGame.PlayerShoot();
    }

    public void CharacterShootAnimation()
    {
        anim.SetTrigger("Draw");
    }

    public void RunAnimation()
    {
        anim.SetBool("Running", true);
    }

    public void DrawIdleAnimation()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Lost Draw", false);
        anim.SetTrigger("Quick Draw Idle");
    }

    public void Celebrate()
    {
        anim.SetBool("Running", false);
        anim.SetBool("Lost Draw", false);
        anim.SetBool("Celebrate", true);
    }
}
