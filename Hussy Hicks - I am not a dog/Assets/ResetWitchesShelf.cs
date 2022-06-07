using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWitchesShelf : MonoBehaviour
{
    [SerializeField] WitchGameScript witchGameScript;


    public void ResetGame()
    {
        witchGameScript.ResetAnimations();
        witchGameScript.RandomiseIngredientObjects();
        
    }
}
