using UnityEngine;

public class PlayMusicGoodEnd : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] bool played = false;
    
    public void PlayEndSong()
    {
        if(played == false)
        {
            audioSource.Play();
            played = true;
        }
    }
}
