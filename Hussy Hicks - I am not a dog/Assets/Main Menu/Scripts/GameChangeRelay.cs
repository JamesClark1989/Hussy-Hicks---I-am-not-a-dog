using UnityEngine;

public class GameChangeRelay : MonoBehaviour
{
    [SerializeField] GameSwitchScript gameSwitchScript;

    public void CallChangeGameContents()
    {
        gameSwitchScript.ChangeGameContents();
    }
}
