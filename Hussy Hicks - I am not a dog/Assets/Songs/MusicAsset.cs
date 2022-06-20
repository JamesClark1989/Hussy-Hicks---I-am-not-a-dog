using UnityEngine;

[CreateAssetMenu(fileName = "New Song Asset", menuName = "Song Asset")]
public class MusicAsset : ScriptableObject
{
    public AudioClip songClip;
    public string songName;
}
