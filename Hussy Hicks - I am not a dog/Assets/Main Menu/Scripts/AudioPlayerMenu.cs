using UnityEngine;
using TMPro;

public class AudioPlayerMenu : MonoBehaviour
{
    [SerializeField] MusicAsset[] musicAsset;
    [SerializeField] AudioSource audioSource;
    [SerializeField] int currentSong;

    [SerializeField] TMP_Text songTitle;

    private void Start()
    {
        PlaySong();
    }

    public void SelectSong(int elementChanger)
    {
        CancelInvoke();
        currentSong += elementChanger;
        if (currentSong < 0) currentSong = musicAsset.Length - 1;
        else if (currentSong >= musicAsset.Length)
        {
            currentSong = 0;
        }

        PlaySong();
    }
  

    public void PlaySong()
    {
        audioSource.Stop();
        audioSource.clip = musicAsset[currentSong].songClip;
        audioSource.Play();

        ChangeSongTitle();

        Invoke("AutoPlayNextSong", audioSource.clip.length);
    }

    void AutoPlayNextSong()
    {
        SelectSong(1);
    }


    void ChangeSongTitle()
    {
        songTitle.SetText($"Hussy Hicks\n------------------\n{musicAsset[currentSong].songName}");    }
}
