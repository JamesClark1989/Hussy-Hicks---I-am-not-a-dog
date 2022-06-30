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
    [SerializeField] bool gameRunning = true;
    string walking = "Walking";
    [SerializeField] string[] animationParams = { "Left Snip", "Right Snip", "Sting" };
    void Start()
    {
        timer = 0.5f;
        randomAnim = animationParams[0];
    }

    void Update()
    {
        if(gameRunning == true)
        {
            if (battling && attackCounter < attackCounterMax)
            {
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    randomAnim = animationParams[Random.Range(0, animationParams.Length)];
                    scorpionController.SetTrigger(randomAnim);
                    attackCounter++;
                    battling = false;
                }
            }
            if (attackCounter == attackCounterMax)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)                {

                    StopBattlingGoodEnd();
                }
            }
        }

        
    }

    public void ResetTimerAfterAttack()
    {
        timer = timerMax;
        //timerMax -= 0.1f;
        battling = true;
    }

    public void PauseBattling()
    {
        battling = false;
        attackCounter--;
    }

    public void ContinueBattling()
    {
        timer = 1.5f;
        battling = true;
    }

    public void StopBattlingGoodEnd()
    {
        gameRunning = false;
        gateController.SetBool("OpenGate", true);
        scorpionMovementController.SetBool("ScorpionBackoff", true);
        scorpionDodgeGame.FinishedLevel();
        attackCounter++;
    }

    public void StopBattlingBadEnd()
    {
        gameRunning = false;
        battling = false;
        gateController.SetBool("OpenGate", false);
        attackCounter++;
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
