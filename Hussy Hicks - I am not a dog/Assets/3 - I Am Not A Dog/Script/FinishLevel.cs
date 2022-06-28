using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterRunScript>().enabled = false;
            CharacterAnimationOnly animation = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimationOnly>();
            animation.enabled = true;
            animation.CelebratePuttWin();
            GameManagerDog.instance.SavedCurrentHussyHick(true);
            Destroy(gameObject);
        }
    }
}
