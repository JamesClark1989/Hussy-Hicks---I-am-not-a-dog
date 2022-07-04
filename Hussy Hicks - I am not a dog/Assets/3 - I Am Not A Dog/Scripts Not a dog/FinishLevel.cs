using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] GameObject optionalObjectToDestroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (optionalObjectToDestroy != null)
                Destroy(optionalObjectToDestroy);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterRunScript>().enabled = false;
            CharacterAnimationOnly animation = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterAnimationOnly>();
            animation.enabled = true;
            animation.CelebratePuttWin();
            GameManagerDog.instance.SavedCurrentHussyHick(true);
            Destroy(gameObject);
            FindObjectOfType<LoadMiniGameCallback>().ShowWaitForTimer();
        }
    }
}
