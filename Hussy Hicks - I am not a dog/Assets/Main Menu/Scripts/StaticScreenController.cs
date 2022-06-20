using UnityEngine;

public class StaticScreenController : MonoBehaviour
{
    [SerializeField] GameObject staticScreen;
    
    public void TurnOnStatic()
    {
        staticScreen.SetActive(true);
    }

    public void TurnOffStatic()
    {
        staticScreen.SetActive(false);
    }
}
