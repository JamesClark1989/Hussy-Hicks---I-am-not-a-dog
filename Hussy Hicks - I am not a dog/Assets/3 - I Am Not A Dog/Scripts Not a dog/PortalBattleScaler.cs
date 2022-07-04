using UnityEngine;

public class PortalBattleScaler : MonoBehaviour
{
    [SerializeField] Transform evilPortal;
    [SerializeField] Transform goodPortal;

    [SerializeField] GameObject battleScene;
    [SerializeField] GameObject hussysWinEnding;
    [SerializeField] GameObject hussysLoseEnding;

    [SerializeField] float currentScale;
    [SerializeField] float maxScale;
    [SerializeField] float recoveryRate;
    [SerializeField] float maxPush;

    [SerializeField] bool battleWagesOn = true;

    private void Start()
    {
        SetRecoveryRateValue();
    }

    void Update()
    {

        if(evilPortal.gameObject != null)
        {
            // Evil Scale
            float currentEvilScaleZ = evilPortal.localScale.z;
            float newEvilScaleZ = currentEvilScaleZ += currentScale * Time.deltaTime;
            evilPortal.localScale = new Vector3(1, 1, newEvilScaleZ);
        }

        if(goodPortal.gameObject != null)
        {
            // Good Scale
            float currentGoodScaleZ = goodPortal.localScale.z;
            float newGoodScaleZ = currentGoodScaleZ -= currentScale * Time.deltaTime;
            goodPortal.localScale = new Vector3(1, 1, newGoodScaleZ);
        }


        if (battleWagesOn)
        {

            if (goodPortal.localScale.z > 0.1f)
                currentScale = Mathf.MoveTowards(currentScale, maxScale, recoveryRate * Time.deltaTime);
            else
                currentScale = 0;
        }
        else
        {
            currentScale = Mathf.MoveTowards(currentScale, maxScale, recoveryRate * 6 * Time.deltaTime);
            if (evilPortal.localScale.z < 0.05f)
                evilPortal.gameObject.SetActive(false);
            else if (goodPortal.localScale.z < 0.05f)
                goodPortal.gameObject.SetActive(false);
        }


    }

    public void AddToScaler()
    {
        // 0.05
        float randomScale = Random.Range(maxPush / 3, maxPush);
        if(currentScale >= -0.1f && evilPortal.localScale.z > 0.1f)
        {
            currentScale -= randomScale;
        }

    }

    public void CheckWhoWon()
    {
        if(evilPortal.localScale.z > goodPortal.localScale.z)
        {
            hussysLoseEnding.SetActive(true);
            maxScale = .5f;
        }
        else if (evilPortal.localScale.z < goodPortal.localScale.z)
        {
            hussysWinEnding.SetActive(true);
            maxScale = -.5f;
        }

        battleWagesOn = false;

        battleScene.SetActive(false);
    }

    void SetRecoveryRateValue()
    {
        maxPush = GameManagerDog.instance.GetRecoveryRate();
    }
}
