using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManagerDog : MonoBehaviour
{
    public static GameManagerDog instance;

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

    [SerializeField] GameObject miniGameSpawned;


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
        print(currentCharacter);
        if(currentCharacter >= hussyHicks.Length)
        {
            SceneManager.LoadScene("Hussy Hack Battle");
        }
        else
        {

            savedTextAnim.SetBool("Finished", false);
            Instantiate(transitionHallway);
        }
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
    }    
    
    public void SetSavedText()
    {
        string hussyName = hussyHicks[currentCharacter].GetComponent<HussyDetails>().GetHussyName();
        savedText.SetText(hussyName + "\nSAVED!!!");
        
    }

    public void ShowSavedOrNotSavedText()
    {
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
            miniGameSpawned = Instantiate(miniGameRooms[currentMiniGameRoom]);
            currentMiniGameRoom++;
        }
        savedTextAnim.SetBool("Finished", false);

    }

    public void DestroyMiniGame()
    {
        UnparentCamera();

        var character = GameObject.FindGameObjectWithTag("Player");
        if (character != null) Destroy(character);
        
        //var level = GameObject.FindGameObjectWithTag("Level");
        if(miniGameSpawned != null) Destroy(miniGameSpawned);
    }

    public void SavedCurrentHussyHick(bool saved)
    {

        // Take a few seconds to show SAVED or NOT SAVED text before next mini game
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

    public void CurrentMiniGameFinished()
    {
        transitionAnimation.SetTrigger("End Game");
    }

    public void LoadNextLevel()
    {
        transitionAnimation.SetTrigger("ChangeMiniGame");
    }

    public GameObject GetCurrentCharacter()
    {
        return hussyHicks[currentCharacter];
    }

    public void TriggerMiniGameEndScene()
    {
        IEndOfMiniGame endGame = miniGameSpawned.GetComponent<IEndOfMiniGame>();
        endGame.EndGameFunction();
    }


    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void UnparentCamera()
    {
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.SetParent(null);
    }
}
