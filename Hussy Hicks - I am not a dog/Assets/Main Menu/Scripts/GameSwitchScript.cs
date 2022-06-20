using UnityEngine;
using TMPro;

public class GameSwitchScript : MonoBehaviour
{
    [SerializeField] CartridgeAsset[] cartridges;

    [SerializeField] int gameNumber;

    [SerializeField] TMP_Text gameText;

    [SerializeField] Renderer rend;

    [SerializeField] Material gameScreenMat;
    [SerializeField] Material cartridgeMaterial;

    [SerializeField] Animator gameCartridgeAnim;


    public void SetGame(int elementCounter)
    {
        gameNumber += elementCounter;
        if (gameNumber >= cartridges.Length) gameNumber = 0;
        else if (gameNumber < 0) gameNumber = cartridges.Length - 1;

        gameCartridgeAnim.SetTrigger("Change Cartridge");
    }

    public void ChangeGameContents()
    {
        // Set Text
        gameText.SetText(cartridges[gameNumber].gameName);

        // Set Texture offset
        gameScreenMat.mainTextureOffset = cartridges[gameNumber].textureCoords;
        cartridgeMaterial.mainTextureOffset = cartridges[gameNumber].textureCoords;
    }

    public void PlayGame()
    {
        // load the scene with the number on the current cartridge
    }
}
