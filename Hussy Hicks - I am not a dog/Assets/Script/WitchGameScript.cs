using System.Collections;
using UnityEngine;

public class WitchGameScript : MonoBehaviour
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

    [SerializeField] WitchIngredientSpeech witchIngredientSpeech;

    void Start()
    {
        SelectRandomIngredients();
        RandomiseIngredientObjects();
    }

  
    void SelectRandomIngredients()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            string temp = ingredients[i];
            int randomIndex = Random.Range(i, ingredients.Length);
            ingredients[i] = ingredients[randomIndex];
            ingredients[randomIndex] = temp;
        }

        for (int i = 0; i < 3; i++)
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

    public void CheckCurrentIngredient(string ingredientDropped)
    {
        if(ingredientDropped == correctIngredients[currentIngredient])
        {
            if (currentIngredient < 3) currentIngredient++;
            else currentIngredient = 0;
        }
        else
        {
            WrongIngredient();
        }
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
        yield return new WaitForSeconds(5);
        cameraAnim.SetTrigger("Show Cauldron and Shelf");
        yield return new WaitForSeconds(1);
        CanDragObjects();
    }
}
