using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] bool manualGame = false;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject[] hussyHicks;
    [SerializeField] int currentCharacter;
    [SerializeField] List<int> savedHicksNumber = new List<int>();

    [SerializeField] GameObject[] miniGameRooms;
    [SerializeField] int currentMiniGameRoom;

    [SerializeField] Animator transitionAnimation;
    [SerializeField] GameObject transitionHallway;
    [SerializeField] GameObject mainCamera;

    [SerializeField] TMP_Text savedText;
    [SerializeField] Animator savedTextAnim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(!manualGame) RandomiseMiniGames();
        RandomiseHussyHicks();
    }

    public void LoadHallway()
    {
        savedTextAnim.SetBool("Finished", false);
        Instantiate(transitionHallway);
    }

    // Save a list of integer values for preselected mini games
    void RandomiseMiniGames()
    {

        for (int i = 0; i < miniGameRooms.Length; i++)
        {
            GameObject temp = miniGameRooms[i];
            int randomIndex = Random.Range(i, miniGameRooms.Length);
            miniGameRooms[i] = miniGameRooms[randomIndex];
            miniGameRooms[randomIndex] = temp;
        }

    }

    void RandomiseHussyHicks()
    {
        for (int i = 0; i < hussyHicks.Length; i++)
        {
            GameObject temp = hussyHicks[i];
            int randomIndex = Random.Range(i, hussyHicks.Length);
            hussyHicks[i] = hussyHicks[randomIndex];
            hussyHicks[randomIndex] = temp;
        }
    }

    public void SetNotSavedText()
    {


        string hussyName = hussyHicks[currentCharacter].GetComponent<HussyDetails>().GetHussyName();
        savedText.SetText(hussyName + "\nNOT SAVED");
        savedTextAnim.SetBool("Finished", true);
    }    
    
    public void SetSavedText()
    {
        string hussyName = hussyHicks[currentCharacter].GetComponent<HussyDetails>().GetHussyName();
        savedText.SetText(hussyName + "\nSAVED!!!");
        savedTextAnim.SetBool("Finished", true);
    }

    public void SpawnMiniGameRoom()
    {
        if(currentMiniGameRoom < 4)
        {
            // Destroy current game
            var hallway = GameObject.FindGameObjectWithTag("Hallway");
            if (hallway != null) Destroy(hallway.gameObject);

            mainCamera.SetActive(true);
            Instantiate(miniGameRooms[currentMiniGameRoom]);
            currentMiniGameRoom++;
        }
        savedTextAnim.SetBool("Finished", false);

    }

    public void DestroyMiniGame()
    {
        var character = GameObject.FindGameObjectWithTag("Player");
        if (character != null) Destroy(character);
        
        var level = GameObject.FindGameObjectWithTag("Level");
        if(level != null) Destroy(level);
    }

    public void SavedCurrentHussyHick(bool saved)
    {
        // If saved, add character iterator to list
        if (!savedHicksNumber.Contains(currentCharacter))
        {
            if (saved)
            {
                savedHicksNumber.Add(currentCharacter);
                SetSavedText();
            }
            else
            {
                SetNotSavedText();
            }            
        }
    
    }

    public void ChangeNextCharacter()
    {
        currentCharacter++;
    }

    public void LoadNextLevel()
    {
        transitionAnimation.SetTrigger("ChangeMiniGame");
    }

    public GameObject GetCurrentCharacter()
    {
        return hussyHicks[currentCharacter];
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
