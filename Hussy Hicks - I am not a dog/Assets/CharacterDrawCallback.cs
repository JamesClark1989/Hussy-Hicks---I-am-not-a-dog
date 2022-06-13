using UnityEngine;

public class CharacterDrawCallback : MonoBehaviour
{
    [SerializeField] CharacterDrawGameScript characterDrawGameScript;
    [SerializeField] QuickDrawGame quickDrawGame;

    public void SetQuickDrawGameScript(QuickDrawGame qdg)
    {
        quickDrawGame = qdg;
    }

    public void SetCharacterDrawScript(CharacterDrawGameScript newScript)
    {
        characterDrawGameScript = newScript;
    }


    public void DrawGun()
    {
        //characterDrawGameScript.CharacterShoot();
    }

    public void Run()
    {
        characterDrawGameScript.RunAnimation();
    }

    public void DrawGunIdle()
    {
        characterDrawGameScript.DrawIdleAnimation();
    }

    void StartGame()
    {
        quickDrawGame.ResetGame();
    }

}
