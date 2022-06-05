using UnityEngine;

public class Animation_Trigger : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] string animationName;
    [SerializeField] float timerMax;
    [SerializeField] float timer;

    void Start()
    {
        timer = timerMax;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            anim.SetTrigger(animationName);
            timer = timerMax;
        }
    }
}
