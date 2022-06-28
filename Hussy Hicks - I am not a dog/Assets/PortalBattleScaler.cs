using UnityEngine;

public class PortalBattleScaler : MonoBehaviour
{
    [SerializeField] Transform evilPortal;
    [SerializeField] Transform goodPortal;

    [SerializeField] float currentScale;
    [SerializeField] float maxScale;
    [SerializeField] float recoveryRate;


    void Update()
    {
        // Evil Scale
        float currentEvilScaleZ = evilPortal.localScale.z;
        float newEvilScaleZ = currentEvilScaleZ += currentScale * Time.deltaTime;
        evilPortal.localScale = new Vector3(1, 1, newEvilScaleZ);

        // Good Scale
        float currentGoodScaleZ = goodPortal.localScale.z;
        float newGoodScaleZ = currentGoodScaleZ -= currentScale * Time.deltaTime;
        goodPortal.localScale = new Vector3(1, 1, newGoodScaleZ);

        currentScale = Mathf.MoveTowards(currentScale, maxScale, recoveryRate * Time.deltaTime);

    }

    public void AddToScaler()
    {
        float randomScale = Random.Range(0.02f, 0.05f);
        if(currentScale >= -0.1f)
        {
            currentScale -= randomScale;
        }

    }
}
