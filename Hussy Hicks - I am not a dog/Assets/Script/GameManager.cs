using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject currentCharacter;

    [SerializeField] GameObject[] miniGameRooms;
    [SerializeField] int currentMiniGameRoom;
    [SerializeField] List<int> alreadyPlayedMiniGames = new List<int>();
    [SerializeField] GameObject currentMiniGameSpawned;

    [SerializeField] Animator transitionAnimation;
    [SerializeField] GameObject transitionHallway;
    [SerializeField] GameObject mainCamera;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //LoadHallway();
        //SelectMiniGameRoom();
        //SpawnMiniGameRoom();
    }

    public void LoadHallway()
    {
        Instantiate(transitionHallway);
    }


    public void SelectMiniGameRoom()
    {
        currentMiniGameRoom = Random.Range(0, miniGameRooms.Length);
        while (alreadyPlayedMiniGames.Contains(currentMiniGameRoom))
        {
            currentMiniGameRoom = Random.Range(0, miniGameRooms.Length);
        }
        alreadyPlayedMiniGames.Add(currentMiniGameRoom);
    }

    public void SpawnMiniGameRoom()
    {
        var hallway = GameObject.FindGameObjectWithTag("Hallway");
        if(hallway != null) Destroy(hallway.gameObject);
        mainCamera.SetActive(true);
        Instantiate(miniGameRooms[currentMiniGameRoom]);
    }

    public void DestroyMiniGame()
    {
        var character = GameObject.FindGameObjectWithTag("Player");
        if (character != null) Destroy(character);
        
        var level = GameObject.FindGameObjectWithTag("Level");
        if(level != null) Destroy(level);
    }

    public void ReloadAnimation()
    {
        transitionAnimation.SetTrigger("ReloadLevel");
    }

    public void LoadNewLevel()
    {
        transitionAnimation.SetTrigger("ChangeMiniGame");
    }

    public GameObject GetCurrentCharacter()
    {
        return currentCharacter;
    }


    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }


    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
