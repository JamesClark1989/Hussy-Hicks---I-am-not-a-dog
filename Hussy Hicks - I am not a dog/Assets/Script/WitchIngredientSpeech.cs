using UnityEngine;
using UnityEngine.UI;

public class WitchIngredientSpeech : MonoBehaviour
{
    [SerializeField] Sprite batwing;
    [SerializeField] Sprite toe;
    [SerializeField] Sprite eye;
    [SerializeField] Sprite toad;
    [SerializeField] Sprite gecko;
    [SerializeField] Sprite mushroom;

    [SerializeField] Image[] ingredientImages;


    public void SetupIngredientImages(string[] ingredients)
    {
        print(ingredients);
        for(int i = 0; i < ingredientImages.Length; i++)
        {
            switch (ingredients[i])
            {
                case "Batwing":
                    ingredientImages[i].sprite = batwing;
                    break;            
                case "Eye":
                    ingredientImages[i].sprite = eye;
                    break;                
                case "Mushroom":
                    ingredientImages[i].sprite = mushroom;
                    break;
                case "Toad":
                    ingredientImages[i].sprite = toad;
                    break;
                case "Toe":
                    ingredientImages[i].sprite = toe;
                    break;
                case "Gecko":
                    ingredientImages[i].sprite = gecko;
                    break;
            }
        }
    }

}
