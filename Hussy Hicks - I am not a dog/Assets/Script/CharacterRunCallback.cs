
using UnityEngine;

public class CharacterRunCallback : MonoBehaviour
{
    [SerializeField] CharacterRunScript characterRunScript;

    public void SetCharacterRunScript(CharacterRunScript newScript)
    {
        characterRunScript = newScript;
    }

    public void Run()
    {
        characterRunScript.Run();
    }

    public void StopRunning()
    {
        characterRunScript.DontRun();
    }

    public void RunSetSpeed(float newSpeed)
    {
        characterRunScript.RunSetSpeed(newSpeed);
    }

    public void DrawReadyPosition()
    {
        characterRunScript.DrawReadyPosition();
    }

    public void DrawGun()
    {
        characterRunScript.DrawGun();
    }



}
