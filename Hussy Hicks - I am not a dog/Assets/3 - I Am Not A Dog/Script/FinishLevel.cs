using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public Animator savedAnim;

    private void Start()
    {
        savedAnim = GameObject.FindGameObjectWithTag("Saved Text").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.SavedCurrentHussyHick(true);
            Destroy(gameObject);
        }
    }
}
