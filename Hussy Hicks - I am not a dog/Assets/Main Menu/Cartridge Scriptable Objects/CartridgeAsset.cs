using UnityEngine;

[CreateAssetMenu(fileName = "New Cartridge Asset", menuName = "Cartridge Asset")]
public class CartridgeAsset : ScriptableObject
{
    public int sceneNumber;
    public string gameName;
    public Vector2 textureCoords;
}
