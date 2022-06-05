using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionController : MonoBehaviour
{
    [SerializeField] Animator scorpionController;
    [SerializeField] Animator scorpionMovementController;
    [SerializeField] Animator gateController;
    [SerializeField] ScorpionDodgeGame scorpionDodgeGame;

    [SerializeField] int attackCounter;
    [SerializeField] int attackCounterMax;

    // Battle timers
    [SerializeField] float timerMax;
    [SerializeField] float timer;

    string randomAnim;

    [SerializeField] bool battling = false;
    string walking = "Walking";
    [SerializeField] string[] animationParams = { "Left Snip", "Right Snip", "Sting" };
    void Start()
    {
        timer = timerMax;
        randomAnim = animationParams[0];
    }

    void Update()
    {
        
        if (battling && attackCounter < attackCounterMax)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                randomAnim = animationParams[Random.Range(0, animationParams.Length)];
                scorpionController.SetTrigger(randomAnim);
                attackCounter++;
                timer = timerMax;
            }
        }
        if(attackCounter == attackCounterMax)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {

                gateController.SetBool("OpenGate", true);
                scorpionMovementController.SetBool("ScorpionBackoff", true);
                scorpionDodgeGame.FinishedLevel();
                attackCounter++;
            }
        }
        
    }

    public void StartBattling()
    {
        battling = true;
    }

    public void SetScorpionWalkAnimation()
    {
        scorpionController.SetBool(walking, true);
    }

    public void StopScorpionWalkAnimation()
    {
        scorpionController.SetBool(walking, false);
    }

}
