using UnityEngine;

public class DestroyObjectsAtEnding : MonoBehaviour
{
    [SerializeField] GameObject instrumentsAndGlow;
    [SerializeField] GameObject hussyHacks;
    [SerializeField] GameObject portal;
    [SerializeField] GameObject tapText;
    [SerializeField] GameObject tapButton;
    [SerializeField] GameObject getReadyText;
    [SerializeField] GameObject crowd;
    [SerializeField] GameObject ali;
    [SerializeField] GameObject trace;



    public void DestroyInstruments()
    {
        Destroy(instrumentsAndGlow);
    }

    public void GoodEndingDestroy()
    {
        Destroy(hussyHacks);
        Destroy(portal);
        Destroy(tapText);
        Destroy(tapButton);
        Destroy(getReadyText);
    }

    public void BadEndingDestroy()
    {
        Destroy(hussyHacks);
        Destroy(portal);
        Destroy(tapText);
        Destroy(tapButton);
        Destroy(getReadyText);
        Destroy(crowd);
    }

    public void DestroyAliTrace()
    {
        Destroy(ali);
        Destroy(trace);
    }
}
