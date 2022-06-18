using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggersScorpion : MonoBehaviour
{
    [SerializeField] GameObject deathTriggerLeft;
    [SerializeField] GameObject deathTriggerMiddle;
    [SerializeField] GameObject deathTriggerRight;

    public void ActivateLeftTrigger()
    {
        deathTriggerLeft.SetActive(true);
    }

    public void DeactivateLeftTrigger()
    {
        deathTriggerLeft.SetActive(false);
    }

    public void ActivateMiddleTrigger()
    {
        deathTriggerMiddle.SetActive(true);
    }

    public void DeactivateMiddleTrigger()
    {
        deathTriggerMiddle.SetActive(false);
    }

    public void ActivateRightTrigger()
    {
        deathTriggerRight.SetActive(true);
    }

    public void DeactivateRightTrigger()
    {
        deathTriggerRight.SetActive(false);
    }
}
