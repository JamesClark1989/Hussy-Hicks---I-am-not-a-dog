using UnityEngine;

public class LoadMiniGameCallback : MonoBehaviour
{
    public void LoadMiniGame()
    {
        GameManager.instance.SpawnMiniGameRoom();
    }

    public void DestroyCurrentMiniGame()
    {
        GameManager.instance.DestroyMiniGame();
    }

    public void ChangeMiniGame()
    {
        GameManager.instance.SelectMiniGameRoom();
    }

    public void LoadHallway()
    {
        GameManager.instance.LoadHallway();
    }
}
