using System.Collections;
using UnityEngine;
using Cinemachine;

public class WitchGameScript : MonoBehaviour, IEndOfMiniGame
{
    [SerializeField] string[] ingredients = new string[] { "Batwing", "Eye", "Mushroom", "Toad", "Toe", "Gecko" };
    [SerializeField] string[] correctIngredients = new string[3];
    [SerializeField] int currentIngredient;

    [SerializeField] Transform[] ingredientPositions;
    [SerializeField] Transform[] ingredientObjects;


    [SerializeField] Animator cauldronGlowAnim;
    [SerializeField] Animator witchAnim;
    [SerializeField] Animator speechBubbleAnim;
    [SerializeField] Animator cameraAnim;
    [SerializeField] Animator fadeReset;
    [SerializeField] CharacterAnimationOnly characterAnimationOnly;

    [SerializeField] WitchIngredientSpeech witchIngredientSpeech;

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform cameraPos;

    void Start()
    {
        SetupWitchGame();
        SpawnCharacter();
        SelectRandomIngredients();
        RandomiseIngredientObjects();
    }

    void SetupWitchGame()
    {
        // Set Camera
        var theVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        theVirtualCamera.transform.position = cameraPos.position;
        theVirtualCamera.transform.rotation = cameraPos.rotation;
        theVirtualCamera.transform.SetParent(cameraPos);
    }

    public void SpawnCharacter()
    {
        GameManagerDog.instance.SetSpawnPoint(spawnPoint);
        GameObject theCharacter = Instantiate(GameManagerDog.instance.GetCurrentCharacter(), spawnPoint.localPosition, spawnPoint.rotation);
        theCharacter.GetComponent<CharacterRunScript>().enabled = false;
        theCharacter.transform.SetParent(spawnPoint);
        characterAnimationOnly = theCharacter.GetComponent<CharacterAnimationOnly>();
        characterAnimationOnly.RunAnimation();
    }

    public void CharacterIdle()
    {
        characterAnimationOnly.IdleAnimation();
    }


    void SelectRandomIngredients()
    {
        // Randomise ingredients
        for (int i = 0; i < ingredients.Length; i++)
        {
            string temp = ingredients[i];
            int randomIndex = Random.Range(i, ingredients.Length);
            ingredients[i] = ingredients[randomIndex];
            ingredients[randomIndex] = temp;
        }

        // First 5 ingredients
        for (int i = 0; i < 5; i++)
        {
            correctIngredients[i] = ingredients[i];
        }

        witchIngredientSpeech.SetupIngredientImages(correctIngredients);
    }

    public void RandomiseIngredientObjects()
    {
        for (int i = 0; i < ingredientPositions.Length; i++)
        {
            Transform temp = ingredientPositions[i];
            int randomIndex = Random.Range(i, ingredientPositions.Length);
            ingredientPositions[i] = ingredientPositions[randomIndex];
            ingredientPositions[randomIndex] = temp;
        }

        // Setup ingredients or something

        for (int i = 0; i < ingredientObjects.Length; i++)
        {
            DragWitchIngredient dragScript = ingredientObjects[i].GetComponent<DragWitchIngredient>();
            dragScript.goInCauldron = false;
            dragScript.SetStartPosition(ingredientPositions[i].position);

            FloatingOscillator floatingScript = ingredientObjects[i].GetComponent<FloatingOscillator>();
            floatingScript.enabled = false;


            //ingredientObjects[i].position = ingredientPositions[i].position;
            ingredientObjects[i].rotation = ingredientPositions[i].rotation;

            floatingScript.enabled = true;
        }
    }

    public void CanDragObjects()
    {
        for (int i = 0; i < ingredientObjects.Length; i++)
        {
            ingredientObjects[i].GetComponent<BoxCollider>().enabled = true;
        }
    }

    public void CanNotDragObjects()
    {
        for (int i = 0; i < ingredientObjects.Length; i++)
        {
            ingredientObjects[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void CheckCurrentIngredient(string ingredientDropped)
    {
        if(ingredientDropped == correctIngredients[currentIngredient])
        {
            if (currentIngredient < correctIngredients.Length) currentIngredient++;

            if(currentIngredient >= correctIngredients.Length) 
            {
                //currentIngredient = 0;
                WonGame();
            }
        }
        else
        {
            WrongIngredient();
        }
    }


    public void WonGame()
    {
        FindObjectOfType<LoadMiniGameCallback>().ShowWaitForTimer();
        GameManagerDog.instance.SavedCurrentHussyHick(true);
        cameraAnim.SetTrigger("Show All");
        characterAnimationOnly.CelebratePuttWin();
        CanNotDragObjects();

    }


    private void WrongIngredient()
    {
        cauldronGlowAnim.SetBool("Incorrect", true);
        ResetGame();
    }

    public void StartGameLoop()
    {
        StartCoroutine("Game");
    }

    void ResetGame()
    {
        fadeReset.SetTrigger("Reset");
        currentIngredient = 0;
    }

    public void ResetAnimations()
    {
        cauldronGlowAnim.SetBool("Incorrect", false);
    }

    private IEnumerator Game()
    {
        witchAnim.SetBool("Talking", true);
        speechBubbleAnim.SetTrigger("Show");
        yield return new WaitForSeconds(7);
        cameraAnim.SetTrigger("Show Cauldron and Shelf");
        yield return new WaitForSeconds(1);
        CanDragObjects();
    }

    public void EndGameFunction()
    {

    }

    public void WonMiniGame()
    {

    }

    public void LostMiniGame()
    {

    }


}
