using UnityEngine;

public class TurnOnCharadesAnswers : MonoBehaviour
{
    [SerializeField] GameObject charadesAnswers;
    [SerializeField] Animator anim;

    public void TurnOnCharadesAnswersButtons()
    {
        charadesAnswers.SetActive(true);
    }

    public void PlayWhirlwind()
    {
        anim.SetTrigger("Whirlwind");
    }

}
