using UnityEngine;

public class FinishLevelCharades : MonoBehaviour
{
    [SerializeField] CharadesGame charadesGame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            charadesGame.EndGameFunction();
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterRunScript>().enabled = false;
            CharacterAnimationOnly animation = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimationOnly>();
            animation.enabled = true;
            animation.CelebratePuttWin();
            GameManagerDog.instance.SavedCurrentHussyHick(true);
            Destroy(gameObject);
        }
    }
}
