using UnityEngine;

public class CharacterAnimationOnly : MonoBehaviour
{
    [SerializeField] Animator characterAnim;
    
    public void RunAnimation()
    {
        characterAnim.SetBool("Running", true);
    }

    public void IdleAnimation()
    {
        characterAnim.SetBool("Running", false);
    }

    public void PuttingIdle()
    {
        characterAnim.SetBool("Running", false);
        characterAnim.SetBool("Golf Idle", true);
    }

    public void CelebratePuttWin()
    {
        characterAnim.SetBool("Golf Idle", false);
        characterAnim.SetBool("Celebrate", true);
    }

    public void DiveCorrect()
    {
        float diveAnimation = Random.Range(0f, 1f);
        print(diveAnimation);
        if(diveAnimation <= 0.5f)
        {
            characterAnim.SetTrigger("Dive 1");
        }
        else
        {
            characterAnim.SetTrigger("Dive 2");
        }
    }

    public void DiveFail()
    {
        characterAnim.SetTrigger("Dive Fail");
    }

    public void BackToIdle()
    {
        characterAnim.SetTrigger("Idle");
    }

    public void DivingIdle()
    {
        characterAnim.ResetTrigger("Idle");
        characterAnim.SetBool("Diving", true);
    }
}
