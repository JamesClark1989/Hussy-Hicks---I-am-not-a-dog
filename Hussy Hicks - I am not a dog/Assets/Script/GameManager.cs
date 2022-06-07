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
    [SerializeField] List<int> selectedMiniGames = new List<int>();
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
        SelectMiniGames();
        //SpawnMiniGameRoom();
    }

    public void LoadHallway()
    {
        Instantiate(transitionHallway);
    }

    // Save a list of integer values for preselected mini games
    public void SelectMiniGames()
    {
        for(int i = 0; i < 4; i++)
        {
            currentMiniGameRoom = Random.Range(0, miniGameRooms.Length);
            while (selectedMiniGames.Contains(currentMiniGameRoom))
            {
                currentMiniGameRoom = Random.Range(0, miniGameRooms.Length);
            }
            selectedMiniGames.Add(currentMiniGameRoom);
        }

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


    public void LoadNextLevel()
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
