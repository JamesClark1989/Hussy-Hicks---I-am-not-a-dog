using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchGameScript : MonoBehaviour
{
    [SerializeField] string[] ingredients = new string[] { "Batwings", "Eye", "Mushroom", "Frog Leg", "Finger", "Dust" };
    [SerializeField] string[] correctIngredients = new string[3];
    [SerializeField] int currentIngredient;

    [SerializeField] Transform[] ingredientPositions;
    [SerializeField] Transform[] ingredientObjects;

    [SerializeField] Animator cauldronGlowAnim;

    void Start()
    {
        SelectRandomIngredient();
        RandomiseIngredientObjects();
    }

  
    void SelectRandomIngredient()
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
    }

    void RandomiseIngredientObjects()
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
            ingredientObjects[i].position = ingredientPositions[i].position;
            ingredientObjects[i].rotation = ingredientPositions[i].rotation;
            ingredientObjects[i].GetComponent<FloatingOscillator>().enabled = true;
        }
    }

    public void CheckCurrentIngredient(string ingredientDropped)
    {
        if(ingredientDropped == correctIngredients[currentIngredient])
        {
            print("YEAH!");
            IncreaseIngredientCounter();
        }
        else
        {
            WrongIngredient();
        }
    }

    private void IncreaseIngredientCounter()
    {
        currentIngredient++;
    }

    private void WrongIngredient()
    {
        cauldronGlowAnim.SetBool("Incorrect", true);
    }
}
